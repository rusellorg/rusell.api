using MediatR;
using MongoDB.Bson.Serialization.Conventions;
using Rusell.Companies.Domain;
using Rusell.Companies.Infrastructure.Persistence;
using Rusell.Shared.Domain.Repository.Mongo;
using Rusell.Shared.Helpers;

namespace Companies.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddScoped<ICompanyRepository, MongoDbCompanyRepository>();

        services.AddMediatR(typeof(Program));
        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Companies));

        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };
        ConventionRegistry.Register("camelCase", conventionPack, _ => true);


        return services;
    }
}
