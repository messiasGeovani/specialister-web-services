using Microsoft.Extensions.DependencyInjection;

namespace Configuration
{
    public class Cors
    {
        public static IServiceCollection Setup(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
