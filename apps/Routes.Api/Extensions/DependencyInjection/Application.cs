using Rusell.Routes.Application.Create;

namespace Routes.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<RouteCreator, RouteCreator>();
        
        return services;
    }
}
