using cafe.Domain.Shift.Entity;
using cafe.Domain.Table.Entity;

namespace cafe.Domain.Order.Entity
{
	public class OrderEntity
	{
		public int Id { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.Now;

		public decimal DiscountPercent { get; set; }

		public bool IsGuest { get; set; }

		public string GuestReason { get; set; } = string.Empty;

        public bool IsActive { get; set; }

		public TableEntity Table { get; set; } = null!;

		public ICollection<OrderItemEntity> OrderItems { get; set; } = null!;

        public ShiftEntity ShiftEntity { get; set; } = null!;

		public decimal TotalPrice
        {
            get { return IsGuest ? 0: OrderItems.Sum(items=> items.ItemPrice)*DiscountPercent; }
        }
    }
}