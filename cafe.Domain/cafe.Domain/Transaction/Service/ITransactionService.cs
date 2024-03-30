using cafe.Domain.Common;
using cafe.Domain.Transaction.DTO;

namespace cafe.Domain.Transaction.Service
{
	public interface ITransactionService
	{
		Task<ICollection<ReadTransactionDTO>> GetAllTransactions();

        Task<BaseResponse<PaginatedResult<ICollection<ReadTransactionDTO>>>> GetFilterdTransaction(TransactionFilterDTO filterDTO);
    }
}

