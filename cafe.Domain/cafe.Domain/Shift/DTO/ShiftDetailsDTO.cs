using cafe.Domain.Order.DTO;
using cafe.Domain.Transaction.DTO;

namespace cafe.Domain.Shift.DTO
{
    public class ShiftDetailsDTO
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndTime { get; set; }

        public bool Closed { get; set; }

        public decimal TotalRevenue { get; set; }

        public ICollection<ReadOrderDTO>? Orders { get; set; }

        public ICollection<ReadTransactionDTO>? Transactions { get; set; }
    }
}

