using cafe.Application.Features.Meal.DTO;

namespace cafe.Domain.Features.Meal.Service;

public interface IMealService
{
    Task<ICollection<ReadOnlyMealDto>> GetAllMeals();

    Task<ReadOnlyMealDto> AddMeal(WriteOnlyMealDto dto);

    Task<ReadOnlyMealDto> UpdateMeal(UpdateOnlyMealDto dto);

    Task DeleteMeal(UpdateOnlyMealDto dto);
}