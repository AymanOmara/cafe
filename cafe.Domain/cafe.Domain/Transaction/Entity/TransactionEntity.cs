using cafe.Domain.Shift.Entity;

namespace cafe.Domain.Transaction.Entity
{
	public class TransactionEntity
	{
		public int Id { get; set; }

		public TransactionType TransactionType { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.Now;

		public decimal Amount { get; set; }

		public bool Closed { get; set; }

        public ShiftEntity? Shift { get; set; }
    }
}