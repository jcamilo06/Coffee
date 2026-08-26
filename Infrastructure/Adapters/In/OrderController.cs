using Application.Ports.In;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Infrastructure.Adapters.In
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
            var order = _useCase.ProcessOrder(request.CustomerName, request.Grams, request.CoffeeBeanId, request.BrewingMethodId);
            return Ok(order);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetById(int orderId)
        {
            var order = _useCase.GetOrderById(orderId);
            return Ok(order);
        }
    }
}