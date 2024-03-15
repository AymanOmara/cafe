using cafe.Domain.Category;
using cafe.Domain.Meal;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure
{
	public class CafeDbContext:DbContext
	{
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Catgeories { get; set; }

        public DbSet<MealEntity> Meals { get; set; }

    }
}

