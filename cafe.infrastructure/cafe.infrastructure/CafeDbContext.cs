using cafe.Domain.Category;
using cafe.Domain.Client.Entity;
using cafe.Domain.Employee;
using cafe.Domain.Event.Entity;
using cafe.Domain.Meal;
using cafe.Domain.Order.Entity;
using cafe.Domain.Shift.Entity;
using cafe.Domain.Table.Entity;
using cafe.Domain.Transaction.Entity;
using cafe.Domain.Users.entity;
using cafe.infrastructure.Features.Employee.EntityConfiguration;
using cafe.infrastructure.Features.Event.EntityConfiguration;
using cafe.infrastructure.Features.Order.EntityConfiguration;
using cafe.infrastructure.Features.Roles.EntityConfiguration;
using cafe.infrastructure.Features.Shift.EntityConfiguration;
using cafe.infrastructure.Features.Table.EntityConfiguration;
using cafe.infrastructure.Features.Transaction.EntityConfiguration;
using cafe.infrastructure.Features.User.EntityConfiguration;
using Microsoft.AspNetCore.Identity;
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

            /// ********* Roles **********
            new RolesEntityConfiguration().Configure(builder.Entity<IdentityRole>());

            /// ********* Order **********
            new OrderEntityConfiguration().Configure(builder.Entity<OrderEntity>());

            new OrderItemEntityConfiguration().Configure(builder.Entity<OrderItemEntity>());

            /// ********* Shift **********
            new ShiftEntityConfiguration().Configure(builder.Entity<ShiftEntity>());

            /// ********* User **********
            new UserEntityConfiguration().Configure(builder.Entity<CafeUser>());

            base.OnModelCreating(builder);
        }

        public DbSet<CategoryEntity> Catgeories { get; set; }

        public DbSet<MealEntity> Meals { get; set; }

        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<TableEntity> Tables { get; set; }

        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<EventEntity> Events { get; set; }

        public DbSet<TransactionEntity> TransactionsEntity { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderItemEntity> OrderItems { get; set; }

        public DbSet<ShiftEntity> Shifts { get; set; }
        
        public async Task SeedAdminUser(UserManager<CafeUser> userManager)
        {
            var adminEmail = "ayman55@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new CafeUser
                {
                    UserName = "ayman",
                    Email = adminEmail,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };

                var result = await userManager.CreateAsync(adminUser, "AymanAli@123");
                
                if (!result.Succeeded)
                {
                    var resoan = result.Errors.Select(e=>e.Description).ToList();
                    
                    throw new Exception(string.Join(",",resoan));
                }

                await userManager.AddToRoleAsync(adminUser, CafeRoles.Admin.ToString());
            }
        }
    }
}