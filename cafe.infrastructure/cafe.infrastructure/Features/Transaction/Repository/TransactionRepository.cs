using cafe.Common;
using cafe.Domain.Transaction.Entity;
using cafe.Domain.Transaction.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Transaction.Repository
{
	public class TransactionRepository: ITransactionRepository
    {
        private readonly CafeDbContext _context;
        private readonly LanguageService _localization;
        public TransactionRepository(CafeDbContext context, LanguageService localization)
		{
            _context = context;

            _localization = localization;
		}

        public async Task<TransactionEntity> CreateTransaction(TransactionEntity transactionEntity)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(shift => shift.Closed == false);
            transactionEntity.Shift = shift;
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

