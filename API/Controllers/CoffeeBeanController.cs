using Application.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CoffeeBeanController : ControllerBase
    {
        private readonly ICoffeeBeanQueryUseCase _useCase;
        public CoffeeBeanController(ICoffeeBeanQueryUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("list")]
        public IActionResult ListBeans()
        {
            var beans = _useCase.GetAllCoffeeBeans();
            return Ok(beans);
        }

        [HttpGet("availability")]
        public IActionResult CheckAvailability([FromQuery] int coffeeBeanId, [FromQuery] decimal grams)
        {
            var available = _useCase.CheckAvailability(coffeeBeanId, grams);
            return Ok(new { Available = available });
        }
    }
}
