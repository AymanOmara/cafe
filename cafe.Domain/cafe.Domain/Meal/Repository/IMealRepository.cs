namespace cafe.Domain.Meal.Repository
{
    public interface IMealRepository
    {
        ICollection<MealEntity> GetAllMeals();
        MealEntity AddMeal(MealEntity meal);
        MealEntity UpdateMeal(MealEntity meal);
        void DeleteMeal(MealEntity meal);
    }
}

