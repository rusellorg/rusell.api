using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Rusell.Companies.Domain;

public class Company
{
    public Company()
    {
    }

    [Key, BsonId] public string Nit { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Phone { get; set; } = default!;
}
