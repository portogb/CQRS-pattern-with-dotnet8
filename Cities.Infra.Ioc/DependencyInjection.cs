using Cities.Application.Command.City.CreateCity;
using Cities.Application.Command.City.DeleteCityById;
using Cities.Application.Command.City.UpdateCityById;
using Cities.Application.Mapping;
using Cities.Application.Queries.City.GetCities;
using Cities.Application.Queries.City.GetCityById;
using Cities.Core.Interfaces;
using Cities.Infra.Data.Repositories;
using MediatR;
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
                .AddMediators()
                .AddAutoMapper(typeof(MappingConfiguration))
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCityCommand).Assembly))
                .AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            return services;
        }

        public static IServiceCollection AddMediators(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetCitiesQuery, GetCitiesResponse>, GetCitiesQueryHandler>();
            services.AddScoped<IRequestHandler<CreateCityCommand, CreateCityResponse>, CreateCityCommandHandler>();
            services.AddScoped<IRequestHandler<GetCityByIdQuery, GetCityByIdResponse>, GetCityByIdQueryHandler>();
            services.AddScoped<IRequestHandler<DeleteCityByIdCommand, DeleteCityByIdResponse>, DeleteCityByIdCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCityByIdCommand, UpdateCityByIdResponse>, UpdateCityByIdCommandHandler>();

            return services;
        }
    }
}
