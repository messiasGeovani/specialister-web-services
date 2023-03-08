using UserApi.Interfaces;
using UserApi.Services;

namespace UserApi.Configuration
{
    public class DependencyInjectionConfig
    {
        public IServiceCollection ResolveDependencies(IServiceCollection services)
        {
            services.AddScoped<ITokenService>(TokenService);

            return services;
        }
    }
}
