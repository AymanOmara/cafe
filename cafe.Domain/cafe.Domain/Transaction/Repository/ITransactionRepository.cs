using cafe.Domain.Transaction.Entity;

namespace cafe.Domain.Transaction.Repository
{
	public interface ITransactionRepository
	{
		Task<ICollection<TransactionEntity>> GetAllTransaction();

		Task<TransactionEntity> CreateTransaction(TransactionEntity transactionEntity);
    }
} 

