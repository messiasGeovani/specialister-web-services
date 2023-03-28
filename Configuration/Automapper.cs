using Microsoft.Extensions.DependencyInjection;

namespace Configuration
{
    public class Automapper
    {
        public static IServiceCollection Setup(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
