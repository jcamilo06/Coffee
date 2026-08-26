using API.DTOs;
using Application.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IProcessCoffeeOrderUseCase _useCase;

        public OrderController(IProcessCoffeeOrderUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderRequest request)
        {
            var order = _useCase.ProcessOrder(
                request.CustomerName,
                request.Grams,
                request.CoffeeBeanId,
                request.BrewingMethodId);

            return Ok(order);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetById(int orderId)
        {
            var order = _useCase.GetOrderById(orderId);
            return Ok(order);
        }

        [HttpGet("availability")]
        public IActionResult CheckAvailability([FromQuery] int coffeeBeanId, [FromQuery] decimal grams)
        {
            var available = _useCase.CheckAvailability(coffeeBeanId, grams);
            return Ok(new { Available = available });
        }
    }
}
