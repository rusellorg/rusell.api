using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rusell.Routes.Application.Create;

namespace Routes.Api.Controllers;

[ApiController]
[Route("api/routes")]
public class RouteController : ControllerBase
{
    private readonly IMediator _mediator;
    public RouteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoute(CreateRouteCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

}
