using AutoMapper;

namespace cafe.Domain.Meal.DTO
{
	public class MealProfile:Profile
	{
		public MealProfile()
		{
			CreateMap<MealEntity, ReadOnlyMealDto>();
			CreateMap<WriteOnlyMealDto, MealEntity>();
            CreateMap<UpdateOnlyMealDto, MealEntity>();
        }
	}
}

