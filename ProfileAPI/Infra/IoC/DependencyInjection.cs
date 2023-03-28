using IoC;

namespace ProfileAPI.Infra.IoC
{
    public class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(IServiceCollection services, IConfiguration configuration)
        {
            DependencyContainer.Setup(services, configuration);

            return services;
        }
    }
}
