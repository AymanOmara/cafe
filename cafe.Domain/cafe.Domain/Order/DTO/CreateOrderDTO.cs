namespace cafe.Domain.Order.DTO
{
	public class CreateOrderDTO
	{
        public bool IsTakeAway { get; set; }

        public decimal DiscountPercent { get; set; }

        public bool IsGuest { get; set; }

        public string GuestReason { get; set; } = string.Empty;
        
        public int? TableId { get; set; }

        public ICollection<CreateOrderItemDTO> OrderItems { get; set; } = null!;
    }
}

