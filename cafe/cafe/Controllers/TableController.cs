using cafe.Domain.Table.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _service;

        public TableController(ITableService service)
        {
            _service = service;
        }
        [HttpGet("Tables")]
        public async Task<ActionResult> GetAllTables()
        {
            return Ok(await _service.GetAllTables());
        }
    }
}