using Rusell.Companies.Application.Create;

namespace Companies.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CompanyCreator, CompanyCreator>();

        return services;
    }
}
