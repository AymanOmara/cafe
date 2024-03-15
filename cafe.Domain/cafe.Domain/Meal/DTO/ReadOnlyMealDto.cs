namespace cafe.Domain.Meal.DTO
{
	public class ReadOnlyMealDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
	}
}

