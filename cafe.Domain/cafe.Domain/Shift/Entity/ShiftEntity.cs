using cafe.Domain.Order.Entity;

namespace cafe.Domain.Shift.Entity
{
    public class ShiftEntity
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndTime { get; set; }

        public bool Closed { get; set; }

        public decimal TotalRevenue => Orders == null ? 0: Orders.Sum(order=> order.TotalPrice);

        public ICollection<OrderEntity>? Orders { get; set; }
    }
}