using AutoMapper;
using cafe.Application.Features.Meal.DTO;
using cafe.Domain.Meal;

namespace cafe.Domain.Features.Meal;

public class MealProfile : Profile
{
    public MealProfile()
    {
        CreateMap<MealEntity, ReadOnlyMealDto>();

        CreateMap<WriteOnlyMealDto, MealEntity>();

        CreateMap<UpdateOnlyMealDto, MealEntity>();
    }
}

