using System;
namespace cafe.Domain.Category.Service
{
	public interface ICategoryService
	{
		ICollection<CategoryEntity> GetCategories();
	}
}

