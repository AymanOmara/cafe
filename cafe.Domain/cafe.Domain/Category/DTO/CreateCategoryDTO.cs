using System.ComponentModel.DataAnnotations;

namespace cafe.Domain.Category.DTO
{
	public class CreateCategoryDTO
	{
		[Required]
		public string Name { get; set; } = null!;
	}
}