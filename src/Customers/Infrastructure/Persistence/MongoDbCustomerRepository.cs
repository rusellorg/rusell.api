using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rusell.Customers.Domain;
using Rusell.Shared.Domain.Repository.Mongo;

namespace Rusell.Customers.Infrastructure.Persistence;

public class MongoDbCustomerRepository : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _customers;

    public MongoDbCustomerRepository(IOptions<MongoDbSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.DatabaseName);
        _customers = database.GetCollection<Customer>(options.Value.CollectionName);
    }

    public async Task Save(Customer entity)
    {
        await _customers.InsertOneAsync(entity);
    }

    public async Task<Customer?> Find(string key, bool noTracking)
    {
        return await _customers.Find(x => x.Id == key).FirstOrDefaultAsync();
    }

    public async Task<Customer?> Find(string key)
    {
        return await _customers.Find(x => x.Id == key).FirstOrDefaultAsync();
    }

    public async Task<bool> Any(Expression<Func<Customer, bool>> predicate)
    {
        return await _customers.Find(predicate).AnyAsync();
    }

    public async Task<IEnumerable<Customer>> SearchAll()
    {
        return await _customers.Find(_ => true).ToListAsync();
    }

    public async Task<IEnumerable<Customer>> SearchAll(Expression<Func<Customer, bool>> predicate)
    {
        return await _customers.Find(predicate).ToListAsync();
    }

    public async Task Delete(Customer entity)
    {
        await _customers.DeleteOneAsync(x => x.Id == entity.Id);
    }
}
