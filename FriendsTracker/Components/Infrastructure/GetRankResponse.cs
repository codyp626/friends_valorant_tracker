using System.Globalization;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FriendsTracker.Components.Infrastructure;

[BsonIgnoreExtraElements]
public partial class GetRankResponse
{
    [BsonElement("status")]
    [JsonProperty("status")]
    public long Status { get; set; }

    [BsonElement("data")]
    [JsonProperty("data")]
    public RankData Data { get; set; } = null!;

    public partial class RankData
    {
        [BsonElement("mmr")]
        [JsonProperty("mmr")]
        public MMRHistoryResponse MMR { get; set; } = null!;

        [BsonElement("account")]
        [JsonProperty("account")]
        public Account Account { get; set; } = null!;

        [BsonElement("peak")]
        [JsonProperty("peak")]
        public Peak Peak { get; set; } = null!;

        [BsonElement("current")]
        [JsonProperty("current")]
        public Current Current { get; set; } = null!;

        [BsonElement("seasonal")]
        [JsonProperty("seasonal", NullValueHandling = NullValueHandling.Ignore)]
        public Seasonal[]? Seasonal { get; set; }
    }

    public partial class Account
    {
        [BsonElement("puuid")]
        [JsonProperty("puuid")]
        public string Puuid { get; set; } = null!;

        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [BsonElement("tag")]
        [JsonProperty("tag")]
        public string Tag { get; set; } = null!;
    }

    public partial class Peak
    {
        [BsonElement("season")]
        [JsonProperty("season")]
        public Season Season { get; set; } = null!;

        [BsonElement("ranking_schema")]
        [JsonProperty("ranking_schema")]
        public string RankingSchema { get; set; } = null!;

        [BsonElement("tier")]
        [JsonProperty("tier")]
        public Tier Tier { get; set; } = null!;
    }

    public partial class Current
    {
        [BsonElement("tier")]
        [JsonProperty("tier")]
        public Tier Tier { get; set; } = null!;

        [BsonElement("rr")]
        [JsonProperty("rr")]
        public long RR { get; set; }

        [BsonElement("last_change")]
        [JsonProperty("last_change")]
        public long LastChange { get; set; }

        [BsonElement("elo")]
        [JsonProperty("elo")]
        public long Elo { get; set; }

        [BsonElement("games_needed_for_rating")]
        [JsonProperty("games_needed_for_rating")]
        public long GamesNeededForRating { get; set; }

        [BsonElement("leaderboard_placement")]
        [JsonProperty("leaderboard_placement")]
        public LeaderboardPlacement LeaderboardPlacement { get; set; } = null!;
    }

    public partial class Seasonal
    {
        [BsonElement("season")]
        [JsonProperty("season")]
        public Season Season { get; set; } = null!;

        [BsonElement("wins")]
        [JsonProperty("wins")]
        public long Wins { get; set; }

        [BsonElement("games")]
        [JsonProperty("games")]
        public long Games { get; set; }

        [BsonElement("end_tier")]
        [JsonProperty("end_tier")]
        public Tier EndTier { get; set; } = null!;

        [BsonElement("ranking_schema")]
        [JsonProperty("ranking_schema")]
        public string RankingSchema { get; set; } = null!;

        [BsonElement("leaderboard_placement")]
        [JsonProperty("leaderboard_placement")]
        public LeaderboardPlacement LeaderboardPlacement { get; set; } = null!;

        [BsonElement("act_wins")]
        [JsonProperty("act_wins")]
        public ActWin[] ActWins { get; set; } = null!;
    }

    public partial class Season
    {
        [BsonElement("id")]
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [BsonElement("short")]
        [JsonProperty("short")]
        public string Short { get; set; } = null!;
    }

    public partial class Tier
    {
        [BsonElement("id")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }

    public partial class LeaderboardPlacement
    {
        [BsonElement("rank")]
        [JsonProperty("rank")]
        public long Rank { get; set; }

        [BsonElement("updated_at")]
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public partial class ActWin
    {
        [BsonElement("id")]
        [JsonProperty("id")]
        public long Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}

public partial class GetRankResponse
{
    public static GetRankResponse? FromJson(string json) => JsonConvert.DeserializeObject<GetRankResponse>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this GetRankResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}