using cafe.Domain.Category.DTO;

namespace cafe.Domain.Category.Service
{
    public interface ICategoryService
    {
        Task<ICollection<ReadCategoryDto>> GetCategories();
        Task<ReadCategoryDto> CreateCategory(CreateCategoryDTO dto);
        Task<ReadCategoryDto?> UpdateCategory(UpdateCategoryDTO dto);
        Task DeleteCategory(UpdateCategoryDTO dto);
    }
}
