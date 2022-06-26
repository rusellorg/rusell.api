using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rusell.Routes.Domain;

public class Route
{
    public Route()
    {
        Id = ObjectId.GenerateNewId();
    }
    
    [Key, BsonId] public ObjectId? Id { get; set; }
    
    public string From { get; set; } = default!;
    public string To { get; set; } = default!;
    public decimal Cost { get; set; } = default!;
    public bool IsCustomerPickedUpAtHome { get; set; } = default!;
    public bool IsCustomerDroppedOffAtHome { get; set; } = default!;
    public string CompanyId { get; set; } = default!;
}
