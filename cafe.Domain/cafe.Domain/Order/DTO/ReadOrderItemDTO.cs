using cafe.Application.Features.Meal.DTO;

namespace cafe.Domain.Order.DTO
{
	public class ReadOrderItemDTO
	{
        public int Id { get; set; }

        public ReadOnlyMealDto Meal { get; set; }

        public int Count { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

