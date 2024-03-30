namespace cafe.Domain.Order.DTO
{
	public class UpdateOrderItenDTO
	{
        public int? Id { get; set; }

        public int? MealId { get; set; }

        public int Count { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

