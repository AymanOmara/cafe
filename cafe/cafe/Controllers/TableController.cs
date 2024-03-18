using cafe.Domain.Table.Service;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
	[Route("api/[controller]")]
	public class TableController:Controller
	{
		private readonly ITableService _service;
		public TableController(ITableService service)
		{
			_service = service;
		}
		[HttpGet("Tables")]
		public ActionResult GetAllTables() {
			return Ok(_service.GetAllTables());
		}
	}
}