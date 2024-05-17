using MongoDB.Bson.Serialization.Attributes;


namespace FriendsTracker.Components.Infrastructure;


[BsonIgnoreExtraElements]
public partial class CustomDate
{
    public string dateString { get; set; } = null!;

    public string dataType { get; set; } = null!;

    public long dateBinary { get; set; } = DateTime.MinValue.ToBinary();
}
