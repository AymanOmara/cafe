using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.Application.IOC
{
    public static class ApplicationIOC
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            /// ********* Auth **********
            //builder.Services.AddIdentityApiEndpoints<CafeUser>()
            //   .AddEntityFrameworkStores<CafeDbContext>();
        }
    }
}
