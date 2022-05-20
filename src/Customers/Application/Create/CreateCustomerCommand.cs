using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Customers.Application.Create;

public record CreateCustomerCommand(string Id, string Name, string LastName, string? Email) : Command;
