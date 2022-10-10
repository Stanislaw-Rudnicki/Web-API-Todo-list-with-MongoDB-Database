using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7_MongoDB.Models;

public class TodoDTO
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required]
    [StringLength(100)]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; } = null!;

    [Required]
    [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
    public string Title { get; set; } = null!;

    [StringLength(500)]
    public string Description { get; set; } = String.Empty;

    [Required]
    public States State { get; set; } = States.New;

    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Closed { get; set; }
}
