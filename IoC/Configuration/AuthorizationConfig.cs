using Microsoft.Extensions.DependencyInjection;

namespace IoC.Configuration
{
    public class AuthorizationConfig
    {
        public static IServiceCollection Setup(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Specialist", policy => policy.RequireRole("specialist"));
                options.AddPolicy("Explorer", policy => policy.RequireRole("explorer"));
            });

            return services;
        }
    }
}
