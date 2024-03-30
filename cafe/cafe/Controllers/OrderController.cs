using cafe.Domain.Order.DTO;
using cafe.Domain.Order.Entity;
using cafe.Domain.Order.Service;
using cafe.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
		{
            _service = service;
		}

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO dto) {
            var result = await _service.CreateOrder(dto);
            return result.ToResultResponse();
        }

        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDTO dto)
        {
            var result = await _service.UpdateOrder(dto);
            return result.ToResultResponse();
        }

        [HttpPost("Checkout")]
        public async Task<IActionResult> CheckoutOrder(int orderId,PaymentMethod paymentMethod) {
            var result = await _service.CheckOut(orderId,paymentMethod);
            return result.ToResultResponse();
        }

        [HttpGet("ActiveOrders")]
        public async Task<IActionResult> GetCurrentActiveOrders() {
            var result = await _service.GetCurrentActiveOrders();
            return result.ToResultResponse();
        }
    }
}

