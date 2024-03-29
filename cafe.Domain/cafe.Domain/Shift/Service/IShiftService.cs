using cafe.Domain.Common;
using cafe.Domain.Shift.Entity;

namespace cafe.Domain.Shift.Service
{
	public interface IShiftService
	{
        Task<BaseResponse<ShiftEntity>> StartNewShift();

        Task<BaseResponse<bool>> CloseCurrentShift();

        Task<BaseResponse<ShiftEntity?>> GetCurrentActiveShift();

        Task<BaseResponse<ICollection<ShiftEntity>?>> GetPaginatedShifts(int pageNumber);

        Task<BaseResponse<ShiftEntity?>> GetShiftDetails(int shiftId);

    }
}

