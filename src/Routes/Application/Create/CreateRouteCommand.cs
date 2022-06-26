using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Routes.Application.Create;

public record CreateRouteCommand(
    string From, 
    string To, 
    decimal Cost, 
    bool IsCustomerPickedUpAtHome, 
    bool IsCustomerDroppedOffAtHome, 
    string CompanyId) : Command;
