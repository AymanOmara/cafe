using cafe.Domain.Meal;
using cafe.Domain.Meal.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Meal.Repository
{
    public class MealRepository : IMealRepository
    {
        private readonly CafeDbContext _context;
        public MealRepository(CafeDbContext context)
        {
            _context = context;
        }

        public MealEntity AddMeal(MealEntity meal)
        {
            _context.Meals.Add(meal);
            _context.SaveChanges();
            return meal;
        }

        public void DeleteMeal(MealEntity meal)
        {
            meal.Deleted = true;
            _context.Entry(meal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public ICollection<MealEntity> GetAllMeals()
        {
            return _context.Meals.ToList();
        }

        public MealEntity UpdateMeal(MealEntity meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            _context.SaveChanges();
            return meal;
        }
    }
}

