using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class AutomapperConfig
    {
        public static IServiceCollection Setup(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
