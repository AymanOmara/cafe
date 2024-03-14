using cafe.Application.Features.Category.Service;
using cafe.Domain.Category.Repository;
using cafe.Domain.Category.Service;
using cafe.infrastructure;
using cafe.infrastructure.Features.Category.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.Ioc;

public class DependancyContainer
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddDbContext<CafeDbContext>((options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("cafe"));
        });
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}

