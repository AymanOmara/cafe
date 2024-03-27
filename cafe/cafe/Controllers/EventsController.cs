using cafe.Domain.Event.DTO;
using cafe.Domain.Event.Service;
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
		public async Task<ActionResult> CreateEvent([FromBody] CreateEventDTO dto) {
			return Ok(await _service.CreateEvent(dto));
		}

	}
}

