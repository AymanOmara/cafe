using AutoMapper;
using cafe.Common;
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

        private readonly LanguageService _localization;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, LanguageService localization)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localization = localization;
        }

        public async Task<BaseResponse<ReadCategoryDto>> CreateCategory(CreateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = await _unitOfWork.Categories.Create(entity);
            var mappedResult = _mapper.Map<ReadCategoryDto>(result);
            return new BaseResponse<ReadCategoryDto> { data = mappedResult , statusCode =200,success = true,message = _localization.Getkey("success").Value};
        }

        public async Task<BaseResponse<bool>> DeleteCategory(UpdateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            await _unitOfWork.Categories.Delete(entity);

            return new BaseResponse<bool> {data = true,statusCode = 200,success =true ,message = _localization.Getkey("success").Value };
        }

        public async Task<BaseResponse<ICollection<ReadCategoryDto>>> GetCategories()
        {
            var result = await _unitOfWork.Categories.GetAllRecords();
            var mappedResult = _mapper.Map<List<ReadCategoryDto>>(result);
            return  new BaseResponse<ICollection<ReadCategoryDto>> { statusCode = 200,success = true,data = mappedResult,message = _localization.Getkey("success").Value };
        }

        public async Task<BaseResponse<ReadCategoryDto?>> UpdateCategory(UpdateCategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = await _unitOfWork.Categories.Update(entity);
            var mappedResult = _mapper.Map<ReadCategoryDto>(result);
            return new BaseResponse<ReadCategoryDto?> { data = mappedResult,statusCode = 200,success = true,message = _localization.Getkey("success").Value };
        }
    }
}