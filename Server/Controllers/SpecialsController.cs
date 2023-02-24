using BlazingPizzas.Server.Data.UnitOfWork;
using BlazingPizzas.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizzas.Server.Controllers
{
    [Route("api/specials")]
    [ApiController]
    public class SpecialsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpecialsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaSpecial>>> Get()
        {
            var specials = await _unitOfWork.SpecialsRepository.GetAll();
            return Ok(specials);
        }
    }
}
