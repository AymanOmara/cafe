using cafe.Domain.Transaction.Entity;
using cafe.Domain.Transaction.Service;

namespace cafe.Application.Features.Transaction.Utils
{
	public static class TransactionsUtils
	{
		public static ICollection<TransactionEntity> Filter(this ICollection<TransactionEntity> transactions, TransactionFilterDTO filter) {
            ICollection<TransactionEntity> filterdTransaction = new List<TransactionEntity>();
            if (filter.TransactionType.HasValue)
            {
                filterdTransaction = transactions.Where(t => t.TransactionType == filter.TransactionType).ToList();
            }

            if (filter.StartDate.HasValue)
            {
                filterdTransaction = transactions.Where(t => t.CreatedDate >= filter.StartDate).ToList();
            }

            if (filter.EndDate.HasValue)
            {
                filterdTransaction = transactions.Where(t => t.CreatedDate <= filter.EndDate).ToList();
            }

            if (filter.TransactionId.HasValue)
            {
                filterdTransaction = transactions.Where(t => t.Id == filter.TransactionId).ToList();
            }
            return filterdTransaction;
        }
	}
}

