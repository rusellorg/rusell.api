using MongoDB.Bson;
using Rusell.Shared.Domain.Repository;

namespace Rusell.Routes.Domain;

public interface IRouteRepository : IRepository<Route, ObjectId>
{
}
    
