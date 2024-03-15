using cafe.Domain.Meal.DTO;

namespace cafe.Domain.Meal.Service
{
    public interface IMealService
    {
        ICollection<ReadOnlyMealDto> GetAllMeals();
        ReadOnlyMealDto AddMeal(WriteOnlyMealDto dto);
        ReadOnlyMealDto? UpdateMeal(UpdateOnlyMealDto dto);
        void DeleteMeal(UpdateOnlyMealDto dto);
    }
}

