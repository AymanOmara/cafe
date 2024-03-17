using AutoMapper;
using cafe.Domain.Category;
using cafe.Domain.Category.DTO;
using cafe.Domain.Category.Repository;
using cafe.Domain.Category.Service;

namespace cafe.Application.Features.Category.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ReadCategoryDto CreateCategory(CreateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = _repository.CreateCategory(entity);
            return _mapper.Map<ReadCategoryDto>(result);
        }

        public void DeleteCategory(UpdateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            _repository.DeleteCategory(entity);
        }

        public ICollection<ReadCategoryDto> GetCategories()
        {
            return _mapper.Map<List<ReadCategoryDto>>(_repository.GetCategories());
        }

        public ReadCategoryDto? UpdateCategory(UpdateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = _repository.UpdateCategory(entity);
            return _mapper.Map<ReadCategoryDto>(result);
        }
    }
}