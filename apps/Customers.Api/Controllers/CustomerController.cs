using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Customers.Application.Create;
using Rusell.Customers.Application.Find;

namespace Customers.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(string id)
    {
        var customer = await _mediator.Send(new FindCustomerQuery(id));

        return (customer == null) ? NotFound() : Ok(customer);
      
    }
}
