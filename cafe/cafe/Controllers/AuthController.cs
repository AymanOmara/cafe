using cafe.Domain.Users.DTO;
using cafe.Domain.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
	[Route("api/[controller]")]
	public class AuthController:ControllerBase
	{
		private readonly IUserService _userService;
		public AuthController(IUserService userService)
		{
			_userService = userService;
        }

		[Authorize(Roles = "Admin")]
		[HttpPost("CreateUser")]
		public async Task<ActionResult> CreateUser([FromBody] RegistrationDTO dto) {
			var result = await _userService.CreateUser(dto);
            return Ok(result);
		}
		[AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO dto)
        {
            var result = await _userService.Login(dto);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<ActionResult> RefreshToken([FromBody] TokenDTO dto)
        {
            var result = await _userService.RefreshToken(dto);
            return Ok(result);
        }
    }
}

