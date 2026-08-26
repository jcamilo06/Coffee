using Application.Ports.In;
using Application.Ports.Outs.Interfaces;
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
    }
}
