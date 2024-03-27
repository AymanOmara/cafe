using cafe.Domain.Category;
using cafe.Domain.Client.Entity;
using cafe.Domain.Employee;
using cafe.Domain.Event.Entity;
using cafe.Domain.Meal;
using cafe.Domain.Table.Entity;
using cafe.Domain.Transaction.Entity;
using cafe.Domain.Users.entity;
using cafe.infrastructure.Features.Employee.EntityConfiguration;
using cafe.infrastructure.Features.Event.EntityConfiguration;
using cafe.infrastructure.Features.Table.EntityConfiguration;
using cafe.infrastructure.Features.Transaction.EntityConfiguration;
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

            /// ********* Event **********
            new EventEntityConfiguration().Configure(builder.Entity<EventEntity>());

            /// ********* Transaction **********
            new TransactionEntityConfiguration().Configure(builder.Entity<TransactionEntity>());

            base.OnModelCreating(builder);
        }
        public DbSet<CategoryEntity> Catgeories { get; set; }

        public DbSet<MealEntity> Meals { get; set; }

        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<TableEntity> Tables { get; set; }

        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<EventEntity> Events { get; set; }

        public DbSet<TransactionEntity> TransactionsEntity { get; set; }
    }
}

