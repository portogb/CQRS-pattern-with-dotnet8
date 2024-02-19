using Cities.Application.Mapping;
using Cities.Application.Queries.City;
using Cities.Core.Interfaces;
using Cities.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Cities.Infra.Ioc
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories()
                .AddAutoMapper(typeof(MappingConfiguration))
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCitiesQuery).Assembly))
                .AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            return services;
        }
    }
}
