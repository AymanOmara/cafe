using cafe.Domain.Meal;

namespace cafe.Domain.Category
{
	public class CategoryEntity
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public ICollection<MealEntity>? Meals { get; set; }

	}
}

