using Application.Interfaces;
using Application.Services;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHashService, HashService>();
        }
    }
}
