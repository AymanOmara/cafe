using cafe.Domain.Client.DTO;
using cafe.Domain.Client.Service;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("GetAllClients")]
        public ActionResult GetAllClients()
        {
            return Ok(_service.GetAllClients());
        }

        [HttpPost("CreateClient")]
        public ActionResult CreateClient([FromBody] WriteClientDTO dto) {
            return Ok(_service.AddClient(dto));
        }

        [HttpPut("UpdateClient")]
        public async Task<ActionResult> UpdateClient([FromBody] UpdateClientDTO dto)
        {
            return Ok(await _service.UpdateClient(dto));
        }
        [HttpDelete("DeleteClient")]
        public async Task<ActionResult> DeleteClient([FromBody] UpdateClientDTO dto)
        {
            await _service.DeleteClient(dto);
            return Ok();
        }
    }
}

