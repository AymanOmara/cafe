using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

namespace cafe.Common
{
    //i validator interceptor
    public static class CommonIOC
    {
        public static void RegisterCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<LanguageService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportCultures = new List<CultureInfo>
    {
        new CultureInfo("en"),
        new CultureInfo("ar"),
    };
                options.DefaultRequestCulture = new RequestCulture(culture: "en");
                options.SupportedCultures = supportCultures;
                options.SupportedUICultures = supportCultures;
                options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            });
        }
    }
}

