using AutoMapper;
using cafe.Application.Common;
using cafe.Application.Features.Transaction.Utils;
using cafe.Common;
using cafe.Domain.Common;
using cafe.Domain.Transaction.DTO;
using cafe.Domain.Transaction.Service;

namespace cafe.Application.Features.Transaction.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly LanguageService _localization;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, LanguageService localization)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;

            _localization = localization;
        }

        public async Task<ICollection<ReadTransactionDTO>> GetAllTransactions()
        {
            var result = await _unitOfWork.Transactions.GetAllTransaction();

            return _mapper.Map<List<ReadTransactionDTO>>(result);
        }

        public async Task<BaseResponse<PaginatedResult<ICollection<ReadTransactionDTO>>>> GetFilterdTransaction(TransactionFilterDTO filterDTO)
        {
            var result = await _unitOfWork.Transactions.GetAllTransaction();
            var filterdResult = result.Filter(filterDTO);
            var mappedResult = _mapper.Map<List<ReadTransactionDTO>>(filterdResult);
            var paginatedResult = mappedResult.ToPagition(filterDTO.PageNumber, filterDTO.PageSize);
            
            return new BaseResponse<PaginatedResult<ICollection<ReadTransactionDTO>>> {data = paginatedResult,statusCode = 200,success = true ,message = _localization.Getkey("success").Value};
            
        }
    }
}

