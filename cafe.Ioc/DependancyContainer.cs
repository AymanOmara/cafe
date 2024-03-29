using cafe.Application.Features.Category.Service;
using cafe.Application.Features.Client.Service;
using cafe.Application.Features.Employee.Service;
using cafe.Application.Features.Event;
using cafe.Application.Features.Meal;
using cafe.Domain.Features.Meal.Service;
using cafe.Application.Features.Shift;
using cafe.Application.Features.Table.Service;
using cafe.Application.Features.Transaction.Service;
using cafe.Application.Features.User.Service;
using cafe.Domain.Category.Repository;
using cafe.Domain.Category.Service;
using cafe.Domain.Client.Repository;
using cafe.Domain.Client.Service;
using cafe.Domain.Employee.Repository;
using cafe.Domain.Employee.Service;
using cafe.Domain.Event.Repository;
using cafe.Domain.Event.Service;
using cafe.Domain.Meal.Repository;
using cafe.Domain.Shift;
using cafe.Domain.Shift.Service;
using cafe.Domain.Table.Repository;
using cafe.Domain.Table.Service;
using cafe.Domain.Transaction.Repository;
using cafe.Domain.Transaction.Service;
using cafe.Domain.Users.Repository;
using cafe.Domain.Users.Service;
using cafe.infrastructure;
using cafe.infrastructure.Features.Category.Repository;
using cafe.infrastructure.Features.Client.Repository;
using cafe.infrastructure.Features.Employee.Repository;
using cafe.infrastructure.Features.Event;
using cafe.infrastructure.Features.Meal.Repository;
using cafe.infrastructure.Features.Shift;
using cafe.infrastructure.Features.Table.Repository;
using cafe.infrastructure.Features.Transaction.Repository;
using cafe.infrastructure.Features.User.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.Ioc;

public static class DependancyContainer
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        /// ********* Category **********
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        /// ********* Meal **********
        services.AddScoped<IMealService, MealService>();
        services.AddScoped<IMealRepository, MealRepository>();

        /// ********* Employee **********
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        /// ********* Table **********
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<ITableRepository, TableRepository>();

        /// ********* Client **********
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IClientRepository, ClientRepository>();

        /// ********* Event **********
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IEventRepository, EventRepository>();

        /// ********* Transaction **********
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionService, TransactionService>();


        /// ********* User **********
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        /// ********* Shift **********
        services.AddScoped<IShiftRepository, ShiftRepository>();
        services.AddScoped<IShiftService, ShiftService>();


        services.AddDbContext<CafeDbContext>((options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), builder => builder.MigrationsAssembly("cafe"));
        });
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }
}

