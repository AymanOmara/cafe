using System.ComponentModel.DataAnnotations;

namespace cafe.Domain.Meal.DTO
{
	public class UpdateOnlyMealDto
	{
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}

