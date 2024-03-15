using System.ComponentModel.DataAnnotations.Schema;

namespace cafe.Domain.Meal
{
	public class MealEntity
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public decimal Price { get; set; }

        public bool Deleted { get; set; }

        [ForeignKey("CategoryId")]
		public int CategoryId { get; set; }
	}
}

