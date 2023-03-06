using BlazingPizzas.Server.Data.UnitOfWork;
using BlazingPizzas.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizzas.Server.Controllers
{
    [Route("api/toppings")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToppingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topping>>> Get()
        {
            var toppings = await _unitOfWork.ToppingsRepository.GetAll(
                orderBy: x => x.OrderBy(t => t.Name)
                );
            return Ok(toppings);
        }
    }
}
