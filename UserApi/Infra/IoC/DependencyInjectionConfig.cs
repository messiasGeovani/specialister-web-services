using UserApi.Application.Common.Services;
using UserApi.Application.Common.Interfaces;
using IoC;

namespace UserApi.Infra.IoC
{
    public class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(IServiceCollection services, IConfiguration configuration)
        {
            DependencyContainer.AddPersistance(services, configuration);
            DependencyContainer.RegisterServices(services);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
