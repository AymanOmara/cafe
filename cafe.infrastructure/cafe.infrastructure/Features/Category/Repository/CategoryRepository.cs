using cafe.Domain.Category;
using cafe.Domain.Category.Repository;

namespace cafe.infrastructure.Features.Category.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository()
        {
        }

        public ICollection<CategoryEntity> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}

