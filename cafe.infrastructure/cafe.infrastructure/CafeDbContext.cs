using cafe.Domain.Category;
using cafe.Domain.Client.Entity;
using cafe.Domain.Employee;
using cafe.Domain.Event.Entity;
using cafe.Domain.Meal;
using cafe.Domain.Table.Entity;
using cafe.Domain.Users.entity;
using cafe.infrastructure.Features.Employee.EntityConfiguration;
using cafe.infrastructure.Features.Table.EntityConfiguration;
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
            new EmployeeConiguration().Configure(builder.Entity<EmployeeEntity>());
            new SalaryItemConfiguration().Configure(builder.Entity<SalaryItemEntity>());

            /// ********* Table **********
            new TableEntityConfiguration().Configure(builder.Entity<TableEntity>());

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

