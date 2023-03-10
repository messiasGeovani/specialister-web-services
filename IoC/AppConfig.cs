using IoC.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class AppConfig
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            AuthenticationConfig.Setup(services, configuration);
            AuthorizationConfig.Setup(services);
            AutomapperConfig.Setup(services);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
