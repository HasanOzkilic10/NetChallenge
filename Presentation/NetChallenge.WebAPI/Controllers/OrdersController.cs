using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService= orderService;
        }

        [HttpPost("add")]
        public IActionResult Add(int productId , string nameOfThePersonPlacingTheOrder) //View Model kullanılabilir.
        {
            var order = new Order() { ProductId = productId, NameOfThePersonPlacingTheOrder = nameOfThePersonPlacingTheOrder, OrderDate = DateTime.Now };
            var result  = _orderService.Add(order);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
