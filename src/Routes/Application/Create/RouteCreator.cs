using Mapster;
using Rusell.Routes.Domain;

namespace Rusell.Routes.Application.Create;

public class RouteCreator
{
    private readonly IRouteRepository _repository;

    public RouteCreator(IRouteRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateRouteCommand command)
    {
        var route = command.Adapt<Route>();
        await _repository.Save(route);
    }
}
