namespace cafe.Domain.Order.DTO
{
	public class UpdateOrderDTO
	{
        public int Id { get; set; }

        public decimal DiscountPercent { get; set; }

        public bool IsGuest { get; set; }

        public string GuestReason { get; set; } = string.Empty;

        public int? TableId { get; set; }

        public ICollection<UpdateOrderItenDTO> OrderItems { get; set; } = null!;
    }
}