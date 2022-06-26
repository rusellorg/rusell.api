using MediatR;
using MongoDB.Bson.Serialization.Conventions;
using Rusell.Employees.Domain;
using Rusell.Employees.Infrastructure.Persistence;
using Rusell.Shared.Domain.Repository.Mongo;
using Rusell.Shared.Helpers;

namespace Employees.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddScoped<IEmployeeRepository, MongoDbEmployeeRepository>();

        services.AddMediatR(typeof(Program));
        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Employees));

        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };
        ConventionRegistry.Register("camelCase", conventionPack, _ => true);


        return services;
    }
}
