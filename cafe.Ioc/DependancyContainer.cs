using cafe.infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using cafe.Domain.Common;
using cafe.infrastructure.Common;
using cafe.Common;
using cafe.Application;

namespace cafe.Ioc;

public static class DependancyContainer
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        /// ********* Common **********


        /// ********* InfrastructureIOC **********
        services.RegisterInfrastructureIOC(configuration);

        services.RegisterApplicationIOC();

        services.RegisterCommonServices();
    }
}

