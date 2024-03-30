using AutoMapper;
using cafe.Domain.Category;
using cafe.Domain.Category.DTO;
using cafe.Domain.Category.Service;
using cafe.Domain.Common;

namespace cafe.Application.Features.Category.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReadCategoryDto> CreateCategory(CreateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = await _unitOfWork.Categories.Create(entity);
            return _mapper.Map<ReadCategoryDto>(result);
        }

        public async Task DeleteCategory(UpdateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            await _unitOfWork.Categories.Delete(entity);
        }

        public async Task<ICollection<ReadCategoryDto>> GetCategories()
        {
            var result = await _unitOfWork.Categories.GetAllRecords();
            return  _mapper.Map<List<ReadCategoryDto>>(result);
        }

        public async Task<ReadCategoryDto?> UpdateCategory(UpdateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = await _unitOfWork.Categories.Update(entity);
            return _mapper.Map<ReadCategoryDto>(result);
        }
    }
}