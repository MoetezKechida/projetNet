using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Review
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string ReviewerId { get; set; } = string.Empty;
    public string TargetId { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}