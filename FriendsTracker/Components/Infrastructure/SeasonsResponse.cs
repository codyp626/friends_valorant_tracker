namespace FriendsTracker.Components.Infrastructure;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

public partial class SeasonsResponse
{
    [BsonElement("status")]
    [JsonProperty("status")]
    public int Status { get; set; }

    [BsonElement("data")]
    [JsonProperty("data")]
    public List<Datum>? Data { get; set; }

    public class Datum
    {
        [BsonElement("uuid")]
        [JsonProperty("uuid")]
        public string? Uuid { get; set; }

        [BsonElement("displayName")]
        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [BsonElement("title")]
        [JsonProperty("title")]
        public string? Title { get; set; }

        [BsonElement("type")]
        [JsonProperty("type")]
        public string? Type { get; set; }

        [BsonElement("startTime")]
        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [BsonElement("endTime")]
        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }

        [BsonElement("parentUuid")]
        [JsonProperty("parentUuid")]
        public string? ParentUuid { get; set; }

        [BsonElement("assetPath")]
        [JsonProperty("assetPath")]
        public string? AssetPath { get; set; }
    }
}