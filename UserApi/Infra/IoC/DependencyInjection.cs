using IoC;
using UserApi.Application.Interfaces;
using UserApi.Application.Services;

namespace UserApi.Infra.IoC
{
    public class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(IServiceCollection services, IConfiguration configuration)
        {
            DependencyContainer.Setup(services, configuration);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
