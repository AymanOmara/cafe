using cafe.Domain.Common;
using cafe.Domain.Shift;
using cafe.Domain.Shift.Entity;
using cafe.Domain.Shift.Service;

namespace cafe.Application.Features.Shift
{
	public class ShiftService: IShiftService
    {
		private readonly IShiftRepository _repository;

        public ShiftService(IShiftRepository repository)
		{
			_repository = repository;
		}

        public async Task<BaseResponse<bool>> CloseCurrentShift()
        {
            var result = await _repository.CloseCurrentShift();
            if (!result.IsOk)
            {
                return new BaseResponse<bool> { statusCode = 400, message = result.Error.Message };
            }
            return new BaseResponse<bool> {statusCode = 200, data = true,success = true };
        }

        public async Task<BaseResponse<ShiftEntity?>> GetCurrentActiveShift()
        {
            var result = await _repository.GetCurrentActiveShift();
            if (result == null)
            {
                return new BaseResponse<ShiftEntity?> { statusCode = 400, message = "no current active shift"};
            }
            return new BaseResponse<ShiftEntity?> {statusCode = 200,data = result,success = true };
        }

        public Task<BaseResponse<ICollection<ShiftEntity>?>> GetPaginatedShifts(int pageNumber)
        {

            throw new NotImplementedException();
        }

        public Task<BaseResponse<ShiftEntity?>> GetShiftDetails(int shiftId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ShiftEntity>> StartNewShift()
        {
            var result = await _repository.StartNewShift();
            if (!result.IsOk) {
                return new BaseResponse<ShiftEntity> { statusCode = 400, message = result.Error.Message };
            }
            return new BaseResponse<ShiftEntity> { statusCode = 200, data = result.Value, success = true };
        }
    }
}

