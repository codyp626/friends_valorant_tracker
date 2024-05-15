using System;
using System.Collections.Generic;

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

    public int GetRR(long elo)
    {
        // less than immo 1
        if(elo < 2100)
        {
             elo = elo % 100;
        }

        // immo1 or greater
        else
        {
            elo = elo - 2100;
        }
        return (int) elo;
    }
}

[BsonIgnoreExtraElements]
public partial class BySeason
{
    [BsonElement ("e1a1")]
    [JsonProperty("e1a1")]
    public E1A1 E1A1 { get; set; } = null!;

    [BsonElement ("e1a2")]
    [JsonProperty("e1a2")]
    public E1A2 E1A2 { get; set; } = null!;

    [BsonElement ("e1a3")]
    [JsonProperty("e1a3")]
    public E1A1 E1A3 { get; set; } = null!;

    [BsonElement ("e2a1")]
    [JsonProperty("e2a1")]
    public E1A2 E2A1 { get; set; } = null!;

    [BsonElement ("e2a2")]
    [JsonProperty("e2a2")]
    public E1A1 E2A2 { get; set; } = null!;

    [BsonElement ("e2a3")]
    [JsonProperty("e2a3")]
    public E1A2 E2A3 { get; set; } = null!;

    [BsonElement ("e3a1")]
    [JsonProperty("e3a1")]
    public E1A1 E3A1 { get; set; } = null!;

    [BsonElement ("e3a2")]
    [JsonProperty("e3a2")]
    public E1A2 E3A2 { get; set; } = null!;

    [BsonElement ("e3a3")]
    [JsonProperty("e3a3")]
    public E1A2 E3A3 { get; set; } = null!;

    [BsonElement ("e4a1")]
    [JsonProperty("e4a1")]
    public E1A2 E4A1 { get; set; } = null!;

    [BsonElement ("e4a2")]
    [JsonProperty("e4a2")]
    public E1A2 E4A2 { get; set; } = null!;

    [BsonElement ("e4a3")]
    [JsonProperty("e4a3")]
    public E1A2 E4A3 { get; set; } = null!;

    [BsonElement ("e5a1")]
    [JsonProperty("e5a1")]
    public E1A2 E5A1 { get; set; } = null!;

    [BsonElement ("e5a2")]
    [JsonProperty("e5a2")]
    public E1A1 E5A2 { get; set; } = null!;

    [BsonElement ("e5a3")]
    [JsonProperty("e5a3")]
    public E1A2 E5A3 { get; set; } = null!;

    [BsonElement ("e6a1")]
    [JsonProperty("e6a1")]
    public E1A2 E6A1 { get; set; } = null!;

    [BsonElement ("e6a2")]
    [JsonProperty("e6a2")]
    public E1A2 E6A2 { get; set; } = null!;

    [BsonElement ("e6a3")]
    [JsonProperty("e6a3")]
    public E1A2 E6A3 { get; set; } = null!;

    [BsonElement ("e7a1")]
    [JsonProperty("e7a1")]
    public E1A1 E7A1 { get; set; } = null!;

    [BsonElement ("e7a2")]
    [JsonProperty("e7a2")]
    public E1A1 E7A2 { get; set; } = null!;

    [BsonElement ("e7a3")]
    [JsonProperty("e7a3")]
    public E1A1 E7A3 { get; set; } = null!;

    [BsonElement ("e8a1")]
    [JsonProperty("e8a1")]
    public E1A1 E8A1 { get; set; } = null!;

    [BsonElement ("e8a2")]
    [JsonProperty("e8a2")]
    public E1A2 E8A2 { get; set; } = null!;

    [BsonElement ("e8a3")]
    [JsonProperty("e8a3")]
    public E1A2 E8A3 { get; set; } = null!;
}

public partial class E1A1
{
    [BsonElement ("error")]
    [JsonProperty("error")]
    public string Error { get; set; } = null!;
}

public partial class E1A2 //ACT STATS
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

// public enum Currenttierpatched { Gold1, Gold2, Gold3, Platinum1, Silver1, Silver2, Silver3, Unrated };

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
                //CurrenttierpatchedConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}

// internal class CurrenttierpatchedConverter : JsonConverter
// {
//     public override bool CanConvert(Type t) => t == typeof(Currenttierpatched) || t == typeof(Currenttierpatched?);

//     public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
//     {
//         if (reader.TokenType == JsonToken.Null) return null!;
//         var value = serializer.Deserialize<string>(reader);
//         switch (value)
//         {
//             case "Gold 1":
//                 return Currenttierpatched.Gold1;
//             case "Gold 2":
//                 return Currenttierpatched.Gold2;
//             case "Gold 3":
//                 return Currenttierpatched.Gold3;
//             case "Platinum 1":
//                 return Currenttierpatched.Platinum1;
//             case "Silver 1":
//                 return Currenttierpatched.Silver1;
//             case "Silver 2":
//                 return Currenttierpatched.Silver2;
//             case "Silver 3":
//                 return Currenttierpatched.Silver3;
//             case "Unrated":
//                 return Currenttierpatched.Unrated;
//         }
//         throw new Exception("Cannot unmarshal type Currenttierpatched");
//     }

//     public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
//     {
//         if (untypedValue == null)
//         {
//             serializer.Serialize(writer, null);
//             return;
//         }
//         var value = (Currenttierpatched)untypedValue;
//         switch (value)
//         {
//             case Currenttierpatched.Gold1:
//                 serializer.Serialize(writer, "Gold 1");
//                 return;
//             case Currenttierpatched.Gold2:
//                 serializer.Serialize(writer, "Gold 2");
//                 return;
//             case Currenttierpatched.Gold3:
//                 serializer.Serialize(writer, "Gold 3");
//                 return;
//             case Currenttierpatched.Platinum1:
//                 serializer.Serialize(writer, "Platinum 1");
//                 return;
//             case Currenttierpatched.Silver1:
//                 serializer.Serialize(writer, "Silver 1");
//                 return;
//             case Currenttierpatched.Silver2:
//                 serializer.Serialize(writer, "Silver 2");
//                 return;
//             case Currenttierpatched.Silver3:
//                 serializer.Serialize(writer, "Silver 3");
//                 return;
//             case Currenttierpatched.Unrated:
//                 serializer.Serialize(writer, "Unrated");
//                 return;
//         }
//         throw new Exception("Cannot marshal type Currenttierpatched");
//     }

//    public static readonly CurrenttierpatchedConverter Singleton = new CurrenttierpatchedConverter();
//}