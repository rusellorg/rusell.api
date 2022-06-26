using MediatR;
using MongoDB.Bson.Serialization.Conventions;
using Rusell.Shared.Domain.Repository.Mongo;
using Rusell.Shared.Helpers;

namespace Routes.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        //services.AddScoped<IRouteRepository, MongoDbRouteRepository>();

        services.AddMediatR(typeof(Program));
        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Routes));

        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };
        ConventionRegistry.Register("camelCase", conventionPack, _ => true);


        return services;
    }
}
