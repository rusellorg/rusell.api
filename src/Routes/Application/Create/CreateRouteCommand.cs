using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Routes.Application.Create;

public record CreateRouteCommand(
    string From, 
    string To, 
    decimal Cost, 
    bool IsCustomPicked, 
    bool IsCustomDroppedOffAtHome, 
    string CompanyId) : Command;
