using cafe.Domain.Category;
using cafe.Domain.Category.Repository;
using cafe.Domain.Category.Service;

namespace cafe.Application.Features.Category.Service
{
    public class CategoryService : ICategoryService
    {
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;

        }
        private readonly ICategoryRepository _repository;

        public ICollection<CategoryEntity> GetCategories()
        {
            return _repository.GetCategories();
        }
    }
}

