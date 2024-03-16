using AutoMapper;

namespace cafe.Domain.Category.DTO
{
	public class CategoryProfile:Profile
	{
		public CategoryProfile()
		{
			CreateMap<CategoryEntity, ReadCategoryDto>();
            CreateMap<CreateCategoryDTO, CategoryEntity>();
            CreateMap<UpdateCategoryDTO, CategoryEntity>();
        }
	}
}

