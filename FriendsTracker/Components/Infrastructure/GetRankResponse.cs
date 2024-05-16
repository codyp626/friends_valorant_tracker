using System.Globalization;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FriendsTracker.Components.Infrastructure;

[BsonIgnoreExtraElements]
public partial class GetRankResponse
{
    [BsonElement ("status")]
    [JsonProperty("status")]
    public long Status { get; set; }

    [BsonElement ("data")]
    [JsonProperty("data")]
    public Rank Data { get; set; } = null!;

    //trying without a setter to see
    // public DateTime Date { get; set;} = DateTime.MinValue;
}

public partial class Rank
{
    [BsonElement ("name")]
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [BsonElement ("tag")]
    [JsonProperty("tag")]
    public string Tag { get; set; } = null!;

    [BsonElement ("puuid")]
    [JsonProperty("puuid")]
    public Guid Puuid { get; set; }

    [BsonElement ("current_data")]
    [JsonProperty("current_data")]
    public CurrentData CurrentData { get; set; } = null!;

    [BsonElement ("highest_rank")]
    [JsonProperty("highest_rank")]
    public HighestRank HighestRank { get; set; } = null!;

    [BsonElement ("by_season")]
    [JsonProperty("by_season")]
    public BySeason BySeason { get; set; } = null!;
}

[BsonIgnoreExtraElements]
public partial class BySeason
{
    [BsonElement ("e1a1")]
    [JsonProperty("e1a1")]
    public ACT_STATS E1A1 { get; set; } = null!;

    [BsonElement ("e1a2")]
    [JsonProperty("e1a2")]
    public ACT_STATS E1A2 { get; set; } = null!;

    [BsonElement ("e1a3")]
    [JsonProperty("e1a3")]
    public ACT_STATS E1A3 { get; set; } = null!;

    [BsonElement ("e2a1")]
    [JsonProperty("e2a1")]
    public ACT_STATS E2A1 { get; set; } = null!;

    [BsonElement ("e2a2")]
    [JsonProperty("e2a2")]
    public ACT_STATS E2A2 { get; set; } = null!;

    [BsonElement ("e2a3")]
    [JsonProperty("e2a3")]
    public ACT_STATS E2A3 { get; set; } = null!;

    [BsonElement ("e3a1")]
    [JsonProperty("e3a1")]
    public ACT_STATS E3A1 { get; set; } = null!;

    [BsonElement ("e3a2")]
    [JsonProperty("e3a2")]
    public ACT_STATS E3A2 { get; set; } = null!;

    [BsonElement ("e3a3")]
    [JsonProperty("e3a3")]
    public ACT_STATS E3A3 { get; set; } = null!;

    [BsonElement ("e4a1")]
    [JsonProperty("e4a1")]
    public ACT_STATS E4A1 { get; set; } = null!;

    [BsonElement ("e4a2")]
    [JsonProperty("e4a2")]
    public ACT_STATS E4A2 { get; set; } = null!;

    [BsonElement ("e4a3")]
    [JsonProperty("e4a3")]
    public ACT_STATS E4A3 { get; set; } = null!;

    [BsonElement ("e5a1")]
    [JsonProperty("e5a1")]
    public ACT_STATS E5A1 { get; set; } = null!;

    [BsonElement ("e5a2")]
    [JsonProperty("e5a2")]
    public ACT_STATS E5A2 { get; set; } = null!;

    [BsonElement ("e5a3")]
    [JsonProperty("e5a3")]
    public ACT_STATS E5A3 { get; set; } = null!;

    [BsonElement ("e6a1")]
    [JsonProperty("e6a1")]
    public ACT_STATS E6A1 { get; set; } = null!;

    [BsonElement ("e6a2")]
    [JsonProperty("e6a2")]
    public ACT_STATS E6A2 { get; set; } = null!;

    [BsonElement ("e6a3")]
    [JsonProperty("e6a3")]
    public ACT_STATS E6A3 { get; set; } = null!;

    [BsonElement ("e7a1")]
    [JsonProperty("e7a1")]
    public ACT_STATS E7A1 { get; set; } = null!;

    [BsonElement ("e7a2")]
    [JsonProperty("e7a2")]
    public ACT_STATS E7A2 { get; set; } = null!;

    [BsonElement ("e7a3")]
    [JsonProperty("e7a3")]
    public ACT_STATS E7A3 { get; set; } = null!;

    [BsonElement ("e8a1")]
    [JsonProperty("e8a1")]
    public ACT_STATS E8A1 { get; set; } = null!;

    [BsonElement ("e8a2")]
    [JsonProperty("e8a2")]
    public ACT_STATS E8A2 { get; set; } = null!;

    [BsonElement ("e8a3")]
    [JsonProperty("e8a3")]
    public ACT_STATS E8A3 { get; set; } = null!;
}

public partial class ACT_STATS
{
    [BsonElement ("error")]
    [JsonProperty("error")]
    public string Error { get; set; } = null!;
}

public partial class ACT_STATS //ACT STATS
{
    [BsonElement ("wins")]
    [JsonProperty("wins")]
    public long Wins { get; set; }

    [BsonElement ("number_of_games")]
    [JsonProperty("number_of_games")]
    public long NumberOfGames { get; set; }

    [BsonElement ("final_rank")]
    [JsonProperty("final_rank")]
    public long FinalRank { get; set; }

    [BsonElement ("final_rank_patched")]
    [JsonProperty("final_rank_patched")]
    public string FinalRankPatched { get; set; } = null!;

    [BsonElement ("act_rank_wins")]
    [JsonProperty("act_rank_wins")]
    public ActRankWin[] ActRankWins { get; set; } = null!;

    [BsonElement ("old")]
    [JsonProperty("old")]
    public bool Old { get; set; }
}

public partial class ActRankWin
{
    [BsonElement ("patched_tier")]
    [JsonProperty("patched_tier")]
    public string PatchedTier { get; set; } = null!;

    [BsonElement ("tier")]
    [JsonProperty("tier")]
    public long Tier { get; set; }
}

public partial class CurrentData
{
    [BsonElement ("currenttier")]
    [JsonProperty("currenttier")]
    public long Currenttier { get; set; }

    [BsonElement ("currenttierpatched")]
    [JsonProperty("currenttierpatched")]
    public string Currenttierpatched { get; set; } = null!;

    [BsonElement ("images")]
    [JsonProperty("images")]
    public Images Images { get; set; } = null!;

    [BsonElement ("ranking_in_tier")]
    [JsonProperty("ranking_in_tier")]
    public long RankingInTier { get; set; }

    [BsonElement ("mmr_change_to_last_game")]
    [JsonProperty("mmr_change_to_last_game")]
    public long MmrChangeToLastGame { get; set; }

    [BsonElement ("elo")]
    [JsonProperty("elo")]
    public long Elo { get; set; }

    [BsonElement ("games_needed_for_rating")]
    [JsonProperty("games_needed_for_rating")]
    public long GamesNeededForRating { get; set; }

    [BsonElement ("old")]
    [JsonProperty("old")]
    public bool Old { get; set; }
}

public partial class Images
{
    [BsonElement ("small")]
    [JsonProperty("small")]
    public Uri Small { get; set; } = null!;

    [BsonElement ("large")]
    [JsonProperty("large")]
    public Uri Large { get; set; } = null!;

    [BsonElement ("triangle_down")]
    [JsonProperty("triangle_down")]
    public Uri TriangleDown { get; set; } = null!;

    [BsonElement ("triangle_up")]
    [JsonProperty("triangle_up")]
    public Uri TriangleUp { get; set; } = null!;
}

public partial class HighestRank
{
    [BsonElement ("old")]
    [JsonProperty("old")]
    public bool Old { get; set; }

    [BsonElement ("tier")]
    [JsonProperty("tier")]
    public long Tier { get; set; }

    [BsonElement ("patched_tier")]
    [JsonProperty("patched_tier")]
    public string PatchedTier { get; set; } = null!;

    [BsonElement ("season")]
    [JsonProperty("season")]
    public string Season { get; set; } = null!;
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