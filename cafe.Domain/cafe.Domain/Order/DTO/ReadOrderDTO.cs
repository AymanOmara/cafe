using cafe.Domain.Table.DTO;

namespace cafe.Domain.Order.DTO
{
	public class ReadOrderDTO
	{
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public decimal DiscountPercent { get; set; }

        public bool IsGuest { get; set; }

        public string GuestReason { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public ReadTableDTO Table { get; set; } = null!;

        public ICollection<ReadOrderItemDTO> OrderItems { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}

