using cafe.Domain.Transaction.Entity;

namespace cafe.Domain.Transaction.Service
{
	public class TransactionFilterDTO
	{
        public TransactionType? TransactionType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TransactionId { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; } = 10;
    }
}