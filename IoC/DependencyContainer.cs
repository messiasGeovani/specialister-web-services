using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.Common.Services;
using Application.Modules.Users.Interfaces;
using Application.Modules.Users.UseCases;
using Data.Context;
using Data.Interfaces;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class DependencyContainer
    {
        public static IServiceCollection Setup(IServiceCollection services, IConfiguration configuration)
        {
            AddPersistance(services, configuration);
            RegisterRepositories(services);
            RegisterUseCases(services);
            RegisterServices(services);

            return services;
        }

        private static IServiceCollection AddPersistance(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
           {
               options.UseSqlServer(connectionString);
           });

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            return services;
        }

        private static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }

        private static IServiceCollection RegisterUseCases(IServiceCollection services)
        {
            services.AddScoped<IUserUseCase, UserUseCase>();

            return services;
        }

        private static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<IErrorNotifier, ErrorNotifier>();

            return services;
        }
    }
}
