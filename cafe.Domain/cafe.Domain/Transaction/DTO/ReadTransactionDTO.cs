using cafe.Domain.Transaction.Entity;

namespace cafe.Domain.Transaction.DTO
{
	public class ReadTransactionDTO
	{
        public int Id { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal Amount { get; set; }
    }
}