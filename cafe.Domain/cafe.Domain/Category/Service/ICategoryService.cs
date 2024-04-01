using cafe.Domain.Category.DTO;
using cafe.Domain.Common;

namespace cafe.Domain.Category.Service
{
    public interface ICategoryService
    {
        Task<BaseResponse<ICollection<ReadCategoryDto>>> GetCategories();

        Task<BaseResponse<ReadCategoryDto>> CreateCategory(CreateCategoryDTO dto);

        Task<BaseResponse<ReadCategoryDto?>> UpdateCategory(UpdateCategoryDTO dto);

        Task<BaseResponse<bool>> DeleteCategory(UpdateCategoryDTO dto);
    }
}