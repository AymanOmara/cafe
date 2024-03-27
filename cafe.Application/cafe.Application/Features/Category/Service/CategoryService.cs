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

        public async Task<ReadCategoryDto> CreateCategory(CreateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = await _repository.Create(entity);
            return _mapper.Map<ReadCategoryDto>(result);
        }

        public async Task DeleteCategory(UpdateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            await _repository.Delete(entity);
        }

        public async Task<ICollection<ReadCategoryDto>> GetCategories()
        {
            var result = await _repository.GetAllRecords();
            return  _mapper.Map<List<ReadCategoryDto>>(result);
        }

        public async Task<ReadCategoryDto?> UpdateCategory(UpdateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = await _repository.Update(entity);
            return _mapper.Map<ReadCategoryDto>(result);
        }
    }
}