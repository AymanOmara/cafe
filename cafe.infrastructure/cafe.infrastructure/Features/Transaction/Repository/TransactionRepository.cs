using cafe.Domain.Transaction.Entity;
using cafe.Domain.Transaction.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Transaction.Repository
{
	public class TransactionRepository: ITransactionRepository
    {
        private readonly CafeDbContext _context;

		public TransactionRepository(CafeDbContext context)
		{
            _context = context;
		}

        public async Task<TransactionEntity> CreateTransaction(TransactionEntity transactionEntity)
        {
            await _context.AddAsync(transactionEntity);
            await _context.SaveChangesAsync();
            return transactionEntity;
        }

        public async Task<ICollection<TransactionEntity>> GetAllTransaction()
        {
            return await _context.TransactionsEntity.ToListAsync();
        }

    }
}

