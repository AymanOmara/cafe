using cafe.Domain.Client.DTO;
using cafe.Domain.Client.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("GetAllClients")]
        public async Task<ActionResult> GetAllClients()
        {
            return Ok(await _service.GetAllClients());
        }

        [HttpPost("CreateClient")]
        public async Task<ActionResult> CreateClient([FromBody] WriteClientDTO dto)
        {
            return Ok(await _service.AddClient(dto));
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

