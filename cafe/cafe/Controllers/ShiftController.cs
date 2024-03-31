using cafe.Domain.Shift.Service;
using cafe.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
	[Authorize(Roles = "Admin,Acountent")]
	[Route("api/[controller]")]
	public class ShiftController:ControllerBase
	{
		private readonly IShiftService _shiftService;
        public ShiftController(IShiftService shiftService)
		{
			_shiftService = shiftService;
		}

		[HttpPost("StartNewShift")]
		public async Task<IActionResult> StartNewShift() {
			var result = await _shiftService.StartNewShift();
            return result.ToResultResponse();
        }

        [HttpPost("CloseCurrentShift")]
        public async Task<IActionResult> CloseCurrentShift()
        {
            var result = await _shiftService.CloseCurrentShift();
            return result.ToResultResponse();
        }

        [HttpGet("GetCurrentActiveShift")]
        public async Task<IActionResult> GetCurrentActiveShift()
        {
            var result = await _shiftService.GetCurrentActiveShift();
            return result.ToResultResponse();
        }

        [HttpGet("GetPaginationShifts")]
        public async Task<IActionResult> GetPaginationShifts(int pageNumber,int pageSize)
        {
            var result = await _shiftService.GetPaginatedShifts(pageNumber, pageSize);
            return result.ToResultResponse();
        }

        [HttpGet("Details")]
        public async Task<IActionResult> GetShiftDetails(int shiftId)
        {
            var result = await _shiftService.GetShiftDetails(shiftId);
            return result.ToResultResponse();
        }
    }
}

