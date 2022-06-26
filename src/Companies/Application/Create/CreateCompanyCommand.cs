using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Companies.Application.Create;

public record CreateCompanyCommand(string Nit, string Name, string Address, string Phone) : Command;
