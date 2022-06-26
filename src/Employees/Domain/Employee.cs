using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Rusell.Employees.Domain;

public class Employee
{
    public Employee() {}    
    
    [Key, BsonId] public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Job { get; set; } = default!;
    public string Phone { get; set; } = default!;
}
