using MongoDB.Bson.Serialization.Attributes;


namespace FriendsTracker.Components.Infrastructure;


[BsonIgnoreExtraElements]
public partial class CustomStats
{
    public string dateString { get; set; } = null!;

    public string dataType { get; set; } = null!;

    public long dateBinary { get; set; } = DateTime.MinValue.ToBinary();
    
    //season id support
    public string? seasonId { get; set; } = null!;
}
