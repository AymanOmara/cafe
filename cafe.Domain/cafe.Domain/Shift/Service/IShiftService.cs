using cafe.Domain.Common;
using cafe.Domain.Shift.DTO;
using cafe.Domain.Shift.Entity;

namespace cafe.Domain.Shift.Service
{
	public interface IShiftService
	{
        Task<BaseResponse<ReadShiftDTO>> StartNewShift();

        Task<BaseResponse<bool>> CloseCurrentShift();

        Task<BaseResponse<ReadShiftDTO?>> GetCurrentActiveShift();

        Task<BaseResponse<PaginatedResult<ICollection<ReadShiftDTO>?>>> GetPaginatedShifts(int pageNumber,int perPage);

        Task<BaseResponse<ShiftDetailsDTO?>> GetShiftDetails(int shiftId);

    }
}

