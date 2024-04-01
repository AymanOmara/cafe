using cafe.Domain.Common;
using cafe.infrastructure.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.infrastructure
{
	public static class InfrastructureIOC
	{
		public static void RegisterInfrastructureIOC(this IServiceCollection services,IConfiguration configuration) {

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}

