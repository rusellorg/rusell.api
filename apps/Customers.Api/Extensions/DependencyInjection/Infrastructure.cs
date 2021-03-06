using MediatR;
using MongoDB.Bson.Serialization.Conventions;
using Rusell.Customers.Domain;
using Rusell.Customers.Infrastructure.Persistence;
using Rusell.Shared.Domain.Repository.Mongo;
using Rusell.Shared.Helpers;

namespace Customers.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddScoped<ICustomerRepository, MongoDbCustomerRepository>();

        services.AddMediatR(typeof(Program));
        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Customers));

        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };
        ConventionRegistry.Register("camelCase", conventionPack, _ => true);


        return services;
    }
}
