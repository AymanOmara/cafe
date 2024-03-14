using cafe.Domain.Category.DTO;

namespace cafe.Domain.Category.Service
{
    public interface ICategoryService
    {
        ICollection<ReadCategoryDto> GetCategories();
        ReadCategoryDto CreateCategory(CreateCategoryDTO dto);
        ReadCategoryDto? UpdateCategory(UpdateCategoryDTO dto);
        void DeleteCategory(UpdateCategoryDTO dto);
    }
}
