using BlazingPizzas.Server.Data.UnitOfWork;
using BlazingPizzas.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzas.Server.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            var orders = await _unitOfWork.OrdersRepository.GetAll(
                include: x => x.Include(o => o.Pizzas),
                orderBy: x => x.OrderByDescending(o => o.CreatedTime)
                );

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> Get(int orderId)
        {
            var order = (await _unitOfWork.OrdersRepository.GetAll(
                filter: x => x.Id == orderId,
                include: x =>
                       x.Include(o => o.Pizzas).ThenInclude(p => p.Special)
                        .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping),
                orderBy: x => x.OrderByDescending(o => o.CreatedTime)
                )
                ).FirstOrDefault();

            if(order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder([FromBody] Order order)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            foreach (var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;
                foreach (var topping in pizza.Toppings)
                {
                    topping.ToppingId = topping.Topping.Id;
                    topping.Topping = null;
                }
            }

            _unitOfWork.OrdersRepository.Add(order);
            if(!await _unitOfWork.Save())
            {
                ModelState.AddModelError("", "Error saving");
                return StatusCode(500, ModelState);
            }
            return Ok(order.Id);
        }
    }
}
