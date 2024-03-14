namespace cafe.Domain.Category.Repository
{
	public interface ICategoryRepository
	{
		ICollection<CategoryEntity> GetCategories();
		CategoryEntity CreateCategory(CategoryEntity category);
        CategoryEntity UpdateCategory(CategoryEntity category);
		void DeleteCategory(CategoryEntity category);
    }
}

