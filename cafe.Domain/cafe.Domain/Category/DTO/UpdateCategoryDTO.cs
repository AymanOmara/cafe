using System.ComponentModel.DataAnnotations;

namespace cafe.Domain.Category.DTO
{
	public class UpdateCategoryDTO
	{
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}

