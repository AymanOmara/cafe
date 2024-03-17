using cafe.Application.Features.Meal.DTO;

namespace cafe.Application.Features.Meal.Service
{
    public interface IMealService
    {
        ICollection<ReadOnlyMealDto> GetAllMeals();
        ReadOnlyMealDto AddMeal(WriteOnlyMealDto dto);
        ReadOnlyMealDto UpdateMeal(UpdateOnlyMealDto dto);
        void DeleteMeal(UpdateOnlyMealDto dto);
    }
}

