using AutoMapper;
using cafe.Application.Common;
using cafe.Domain.Common;
using cafe.Domain.Shift;
using cafe.Domain.Shift.DTO;
using cafe.Domain.Shift.Service;

namespace cafe.Application.Features.Shift
{
	public class ShiftService: IShiftService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ShiftService(IUnitOfWork unitOfWork, IMapper mapper)
		{
            _unitOfWork = unitOfWork;
            _mapper = mapper;
		}

        public async Task<BaseResponse<bool>> CloseCurrentShift()
        {
            var result = await _unitOfWork.Shifts.CloseCurrentShift();
            if (!result.IsOk)
            {
                return new BaseResponse<bool> { statusCode = 400, message = result.Error.Message };
            }
            return new BaseResponse<bool> {statusCode = 200, data = true,success = true };
        }

        public async Task<BaseResponse<ReadShiftDTO?>> GetCurrentActiveShift()
        {
            var result = await _unitOfWork.Shifts.GetCurrentActiveShift();
            if (result == null)
            {
                return new BaseResponse<ReadShiftDTO?> { statusCode = 400, message = "no current active shift"};
            }
            var mappedResult = _mapper.Map<ReadShiftDTO>(result);
            return new BaseResponse<ReadShiftDTO?> {statusCode = 200,data = mappedResult, success = true };
        }

        public async Task<BaseResponse<PaginatedResult<ICollection<ReadShiftDTO>?>>> GetPaginatedShifts(int pageNumber,int pageSize)
        {
            var result = await _unitOfWork.Shifts.GetAllShifts();

            var mappedResult = _mapper.Map<List<ReadShiftDTO>>(result);

            var paginatedResult = mappedResult.ToPagition(pageNumber,pageSize);
            
            return new BaseResponse<PaginatedResult<ICollection<ReadShiftDTO>?>> {data = paginatedResult, statusCode = 200,success = true};
        }

        public async Task<BaseResponse<ShiftDetailsDTO?>> GetShiftDetails(int shiftId)
        {
            var result = await _unitOfWork.Shifts.GetShiftDetails(shiftId:shiftId);
            var mappedResult = _mapper.Map<ShiftDetailsDTO>(result);
            return new BaseResponse<ShiftDetailsDTO?> {data = mappedResult,statusCode = 200,message = "",success = true};
        }

        public async Task<BaseResponse<ReadShiftDTO>> StartNewShift()
        {
            var result = await _unitOfWork.Shifts.StartNewShift();
            if (!result.IsOk) {
                return new BaseResponse<ReadShiftDTO> { statusCode = 400, message = result.Error.Message };
            }
            var mappedResult = _mapper.Map<ReadShiftDTO>(result.Value);
            return new BaseResponse<ReadShiftDTO> { statusCode = 200, data = mappedResult, success = true };
        }
    }
}

