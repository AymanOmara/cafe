using cafe.Domain.Category;
using cafe.Domain.Client.Entity;
using cafe.Domain.Employee;
using cafe.Domain.Employee.entity;
using cafe.Domain.Event.Entity;
using cafe.Domain.Meal;
using cafe.Domain.Table.Entity;
using cafe.Domain.Users.entity;
using cafe.infrastructure.Features.Table.Seeder;
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
            /// ********* Employee **********
            builder.Entity<EmployeeEntity>().Ignore(emp => emp.FinalSalary);
            builder.Entity<SalaryItemEntity>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<SalaryIncentiveEntity>("SalaryIncentive")
                .HasValue<PayAdvance>("PayAdvance")
                .HasValue<SalaryDeductionEntity>("SalaryDeduction");

           /// ********* Table **********
            builder.SeedTableEntity();

            base.OnModelCreating(builder);
        }
        public DbSet<CategoryEntity> Catgeories { get; set; }

        public DbSet<MealEntity> Meals { get; set; }

        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<TableEntity> Tables { get; set; }

        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<EventEntity> Events { get; set; }

    }
}

