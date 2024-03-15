using cafe.Domain.Category;
using cafe.Domain.Employee;
using cafe.Domain.Meal;
using cafe.Domain.Users.entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure
{
    public class CafeDbContext : IdentityDbContext<CafeUser>
    {
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SalaryItemEntity>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<SalaryIncentiveEntity>("SalaryIncentive")
                .HasValue<SalaryDeductionEntity>("SalaryDeduction");
            base.OnModelCreating(builder);

        }
        public DbSet<CategoryEntity> Catgeories { get; set; }

        public DbSet<MealEntity> Meals { get; set; }

        public DbSet<EmployeeEntity> Employees { get; set; }

    }
}

