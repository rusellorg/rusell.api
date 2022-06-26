using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Employees.Application.Create;

namespace Employees.Api.Controllers;
[ApiController]
[Route("api/employees")]
public class EmployeeController: ControllerBase
{
    private readonly IMediator _mediator;
    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateEmployee(CreateEmployeeCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (DbUpdateException e)
        {
            return BadRequest(e.Message);
        }
    }
   
}
