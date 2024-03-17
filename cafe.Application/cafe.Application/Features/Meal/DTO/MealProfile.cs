using AutoMapper;
using cafe.Domain.Meal;

namespace cafe.Application.Features.Meal.DTO;

public class MealProfile : Profile
{
    public MealProfile()
    {
        CreateMap<MealEntity, ReadOnlyMealDto>();
        CreateMap<WriteOnlyMealDto, MealEntity>();
        CreateMap<UpdateOnlyMealDto, MealEntity>();
    }
}

