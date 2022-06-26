using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Employees.Application.Create;

public record CreateEmployeeCommand(string Id, string Name, string LastName, string Job, string Phone) : Command;
