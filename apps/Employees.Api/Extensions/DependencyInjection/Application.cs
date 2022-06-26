using Rusell.Employees.Application.Create;

namespace Employees.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<EmployeeCreator, EmployeeCreator>();
        
        return services;
    }
}
