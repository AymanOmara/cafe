using cafe.Domain.Transaction.DTO;

namespace cafe.Domain.Transaction.Service
{
	public interface ITransactionService
	{
		Task<ICollection<ReadTransactionDTO>> GetAllTransactions();

		Task<ICollection<ReadTransactionDTO>> GetFilterdTransaction(TransactionFilterDTO filterDTO);
    }
}

