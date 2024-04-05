using cafe.Domain.Common;
using cafe.Domain.Users.Repository;
using cafe.infrastructure.Common;
using cafe.infrastructure.Features.User.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.infrastructure
{
    public static class InfrastructureIOC
    {
        public static void RegisterInfrastructureIOC(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUserNotifier, UserEmaiINotifier>();
        }
    }
}

