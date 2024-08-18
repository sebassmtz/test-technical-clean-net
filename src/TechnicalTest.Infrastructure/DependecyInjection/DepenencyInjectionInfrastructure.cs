
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Infrastructure.Authentication;
using TechnicalTest.Infrastructure.EntityFramework.Contexts;
using TechnicalTest.Infrastructure.Repositories.GenericRepositories;
using TechnicalTest.Infrastructure.Repositories.UnitOfWork;

namespace TechnicalTest.Infrastructure.DependecyInjection
{
    public static class DepenencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureRepositories(services);
            AddAuthentication(services);
            AddInjections(services);
            ConfigureContext(services, configuration);
            return services;
        }

        public static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextApp>(options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("InventoryConnection"));
                    });
        }

        public static void ConfigureRepositories(IServiceCollection services)
        {
            
        }

        public static void AddAuthentication(IServiceCollection services)
        {
            
        }

        public static void AddInjections(IServiceCollection services)
        {
            services.AddScoped<IAuthorization, AuthenticationProvider>();
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
