using UserApi.Application.Common.Services;
using UserApi.Application.Common.Interfaces;

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
