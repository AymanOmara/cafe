namespace cafe.Domain.Order.DTO
{
	public class CreateOrderItemDTO
	{
        public int? MealId { get; set; }

        public int Count { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

