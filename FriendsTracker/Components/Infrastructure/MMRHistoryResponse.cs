

using System;
using System.Collections.Generic;

using System.Globalization;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FriendsTracker.Components.Infrastructure;

[BsonIgnoreExtraElements]
public partial class MMRHistoryResponse
{
    [BsonElement("status")]
    [JsonProperty("status")]
    public int Status { get; set; }

    [BsonElement("name")]
    [JsonProperty("name")]
    public string? Name { get; set; }

    [BsonElement("tag")]
    [JsonProperty("tag")]
    public string? Tag { get; set; }

    // [BsonElement("results")]
    // [JsonProperty("results")]
    // public Results? Results { get; set; }

    [BsonElement("data")]
    [JsonProperty("data")]
    public Datum[]? Data { get; set; }

    public partial class Results
    {
        [BsonElement("total")]
        [JsonProperty("total")]
        public int? Total { get; set; }

        [BsonElement("returned")]
        [JsonProperty("returned")]
        public int? Returned { get; set; }

        [BsonElement("before")]
        [JsonProperty("before")]
        public int? Before { get; set; }

        [BsonElement("after")]
        [JsonProperty("after")]
        public int? After { get; set; }
    }

    // [BsonIgnoreExtraElements]
    public partial class Datum
    {
        [BsonElement("match_id")]
        [JsonProperty("match_id")]
        public string? MatchId { get; set; }

        [BsonElement("map")]
        [JsonProperty("map")]
        public Map? Map { get; set; }

        [BsonElement("season")]
        [JsonProperty("season")]
        public Season Season { get; set; } = new Season();

        [BsonElement("ranking_in_tier")]
        [JsonProperty("ranking_in_tier")]
        public int RankingInTier { get; set; }

        [BsonElement("last_mmr_change")]
        [JsonProperty("last_mmr_change")]
        public int MmrChangeToLastGame { get; set; }

        [BsonElement("elo")]
        [JsonProperty("elo")]
        public int Elo { get; set; }

        [BsonElement("date")]
        [JsonProperty("date")]
        public string Date { get; set; } = "never";
    }


    public partial class Map
    {
        [BsonElement("id")]
        [JsonProperty("id")]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public partial class Season
    {
        [BsonElement("id")]
        [JsonProperty("id")]
        public string Id { get; set; } = "1";

        [BsonElement("short")]
        [JsonProperty("short")]
        public string Name { get; set; } = "default";
    }

    public partial class Tier
    {
        [BsonElement("id")]
        [JsonProperty("id")]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}


public partial class MMRHistoryResponse
{
    public static MMRHistoryResponse? FromJson(string json) => JsonConvert.DeserializeObject<MMRHistoryResponse>(json, Converter.Settings);
}