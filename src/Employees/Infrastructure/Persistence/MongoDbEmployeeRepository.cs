using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rusell.Employees.Domain;
using Rusell.Shared.Domain.Repository.Mongo;

namespace Rusell.Employees.Infrastructure.Persistence;

public class MongoDbEmployeeRepository: IEmployeeRepository
{
    private readonly IMongoCollection<Employee> _employees;
    public MongoDbEmployeeRepository(IOptions<MongoDbSettings> options)
    {
        var employee = new MongoClient(options.Value.ConnectionString);
        var database = employee.GetDatabase(options.Value.DatabaseName);
        _employees = database.GetCollection<Employee>(options.Value.CollectionName);
        
    }


    public async Task Save(Employee entity) => await _employees.InsertOneAsync(entity);

    public async Task<Employee?> Find(string key, bool noTracking) => await _employees.Find(x => x.Id == key).FirstOrDefaultAsync();

    public async Task<Employee?> Find(string key) => await _employees.Find(x => x.Id == key).FirstOrDefaultAsync();

    public async Task<bool> Any(Expression<Func<Employee, bool>> predicate) => await _employees.Find(predicate).AnyAsync();

    public async Task<IEnumerable<Employee>> SearchAll() => await _employees.Find(x => true).ToListAsync();

    public async Task<IEnumerable<Employee>> SearchAll(Expression<Func<Employee, bool>> predicate) => await _employees.Find(predicate).ToListAsync();

    public async Task Delete(Employee entity) => await _employees.DeleteOneAsync(x => x.Id == entity.Id);
}
