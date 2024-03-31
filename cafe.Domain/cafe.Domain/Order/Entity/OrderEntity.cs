using System.ComponentModel.DataAnnotations.Schema;
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

        public bool IsActive { get; set; } = true;

        [ForeignKey("TableId")]
        public int? TableId { get; set; }

        public TableEntity? Table { get; set; }

		public ICollection<OrderItemEntity> OrderItems { get; set; } = null!;

        public ShiftEntity ShiftEntity { get; set; } = null!;

        public PaymentMethod PaymentMethod { get; set; }

        public bool IsTakeAway { get; set; }

        public decimal TotalPrice
        {
            get { return IsGuest ? 0 : OrderItems.Sum(items => items.TotalPrice)* ((100 - DiscountPercent) / 100); }
        }
    }
}