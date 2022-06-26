using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Rusell.Routes.Domain;
using Rusell.Shared.Domain.Repository.Mongo;

namespace Rusell.Routes.Infrastructure.Persistence;

public class MongoDbRouteRepository : IRouteRepository
{
    private readonly IMongoCollection<Route> _routes;

    public MongoDbRouteRepository(IOptions<MongoDbSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.DatabaseName);

        _routes = database.GetCollection<Route>(options.Value.CollectionName);
    }
    
    public async Task Save(Route entity) => await _routes.InsertOneAsync(entity);

    public async Task<Route?> Find(ObjectId key, bool noTracking) =>
        await _routes.Find(x => x.Id == key).FirstOrDefaultAsync();

    public async Task<Route?> Find(ObjectId key) => await Find(key, false);

    public async Task<bool> Any(Expression<Func<Route, bool>> predicate) =>
        await _routes.Find(predicate).AnyAsync();

    public async Task<IEnumerable<Route>> SearchAll() => await _routes.Find(x => true).ToListAsync();

    public async Task<IEnumerable<Route>> SearchAll(Expression<Func<Route, bool>> predicate) =>
        await _routes.Find(predicate).ToListAsync();

    public async Task Delete(Route entity) => await _routes.DeleteOneAsync(x => x.Id == entity.Id);
}

