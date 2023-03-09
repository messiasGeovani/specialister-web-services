using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class AuthorizationConfig
    {
        public static IServiceCollection Setup(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("manager"));
                options.AddPolicy("Manager", policy => policy.RequireRole("employee"));
            });

            return services;
        }
    }
}
