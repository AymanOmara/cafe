using cafe.Application.Features.Category.Service;
using cafe.Application.Features.Employee.Service;
using cafe.Application.Features.Meal;
using cafe.Application.Features.Meal.Service;
using cafe.Domain.Category.Repository;
using cafe.Domain.Category.Service;
using cafe.Domain.Employee.Repository;
using cafe.Domain.Employee.Service;
using cafe.Domain.Meal.Repository;
using cafe.infrastructure;
using cafe.infrastructure.Features.Category.Repository;
using cafe.infrastructure.Features.Employee.Repository;
using cafe.infrastructure.Features.Meal.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.Ioc;

public class DependancyContainer
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
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

        services.AddDbContext<CafeDbContext>((options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), builder => builder.MigrationsAssembly("cafe"));
        });
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }
}

