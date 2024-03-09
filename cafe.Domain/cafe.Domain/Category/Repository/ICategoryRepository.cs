namespace cafe.Domain.Category.Repository
{
	public interface ICategoryRepository
	{
		ICollection<CategoryEntity> GetCategories();
	}
}

