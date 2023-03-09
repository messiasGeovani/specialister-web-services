using UserApi.Application.Interfaces;
using UserApi.Application.Services;
using UserApi.Interfaces;
using UserApi.Services;

namespace UserApi.Infra
{
    public class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
