using cafe.Common;
using cafe.Domain.Meal;
using cafe.Domain.Meal.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Meal.Repository
{
    public class MealRepository : IMealRepository
    {
        private readonly CafeDbContext _context;
        private readonly LanguageService _localization;
        public MealRepository(CafeDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

        public async Task<MealEntity> Create(MealEntity meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            return meal;
        }

        public async Task Delete(MealEntity meal)
        {
            meal.Deleted = true;
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<MealEntity>> GetAllRecords()
        {
            return await _context.Meals.ToListAsync();
        }

        public async Task<MealEntity> Update(MealEntity meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return meal;
        }
    }
}