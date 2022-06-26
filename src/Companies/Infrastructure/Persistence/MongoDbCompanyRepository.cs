using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rusell.Companies.Domain;
using Rusell.Shared.Domain.Repository.Mongo;

namespace Rusell.Companies.Infrastructure.Persistence;

public class MongoDbCompanyRepository : ICompanyRepository
{
    private readonly IMongoCollection<Company> _companies;

    public MongoDbCompanyRepository(IOptions<MongoDbSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.DatabaseName);

        _companies = database.GetCollection<Company>(options.Value.CollectionName);
    }

    public async Task Save(Company entity) => await _companies.InsertOneAsync(entity);

    public async Task<Company?> Find(string key, bool noTracking) =>
        await _companies.Find(x => x.Nit == key).FirstOrDefaultAsync();

    public async Task<Company?> Find(string key) => await Find(key, false);

    public async Task<bool> Any(Expression<Func<Company, bool>> predicate) =>
        await _companies.Find(predicate).AnyAsync();

    public async Task<IEnumerable<Company>> SearchAll() => await _companies.Find(x => true).ToListAsync();

    public async Task<IEnumerable<Company>> SearchAll(Expression<Func<Company, bool>> predicate) =>
        await _companies.Find(predicate).ToListAsync();

    public async Task Delete(Company entity) => await _companies.DeleteOneAsync(x => x.Nit == entity.Nit);
}
