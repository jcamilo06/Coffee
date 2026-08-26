using Application.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Adapters.In
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BrewingMethodController : ControllerBase
    {
        private readonly IBrewingMethodQueryUseCase _useCase;
        public BrewingMethodController(IBrewingMethodQueryUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("list")]
        public IActionResult ListMethods()
        {
            var methods = _useCase.GetAllBrewingMethods();
            return Ok(methods);
        }
    }
}
