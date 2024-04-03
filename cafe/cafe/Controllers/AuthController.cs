using cafe.Domain.Users.DTO;
using cafe.Domain.Users.Service;
using cafe.Utils;
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
		public async Task<IActionResult> CreateUser([FromBody] RegistrationDTO dto) {
			var result = await _userService.CreateUser(dto);
            return result.ToResultResponse();
		}

		[AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var result = await _userService.Login(dto);
            return result.ToResultResponse();
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDTO dto)
        {
            var result = await _userService.RefreshToken(dto);
            return result.ToResultResponse();
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers() {
            var result = await _userService.GetAllUsers();
            return result.ToResultResponse();
        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId) {
            var result = await _userService.DeleteUser(userId);
            return result.ToResultResponse();
        }
    }
}

