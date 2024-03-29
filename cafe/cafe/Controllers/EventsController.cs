using cafe.Domain.Event.DTO;
using cafe.Domain.Event.Service;
using cafe.Utils;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
	[Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
		private readonly IEventService _service;
        public EventsController(IEventService service)
		{
			_service = service;
		}

		[HttpGet("UpcommingEvents")]
		public async Task<ActionResult> GetUpcommingEvents() {
			return Ok(await _service.GetUpcommingEvents());
		}

		[HttpPost("CreateEvent")]
		public async Task<IActionResult> CreateEvent([FromBody] CreateEventDTO dto) {
			var result = await _service.CreateEvent(dto);
			return result.ToResultResponse();
        }

        [HttpPut("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventDTO dto)
        {
            var result = await _service.UpdateEvent(dto);
            return result.ToResultResponse();
        }

        [HttpPost("CheckOutEvent")]
        public async Task<IActionResult> CheckOut([FromBody] UpdateEventDTO dto)
        {
            var result = await _service.Checkout(dto);
            return result.ToResultResponse();
        }

        [HttpPost("CancelEvent/{id}/{reason}")]
        public async Task<IActionResult> CancelEvent(int id , string reason)
        {
            var result = await _service.CancelEvent(id,reason);
            return result.ToResultResponse();
        }
    }
}