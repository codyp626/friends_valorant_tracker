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

    [BsonElement ("Status")]
    [JsonProperty("status")]
    public long Status { get; set; }

    [BsonElement ("Data")]
    [JsonProperty("data")]
    public Rank Data { get; set; } = null!;
}

public partial class Rank
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("tag")]
    public string Tag { get; set; } = null!;

    [JsonProperty("puuid")]
    public Guid Puuid { get; set; }

    [JsonProperty("current_data")]
    public CurrentData CurrentData { get; set; } = null!;

    [JsonProperty("highest_rank")]
    public HighestRank HighestRank { get; set; } = null!;

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

public partial class BySeason
{
    [JsonProperty("e1a1")]
    public E1A1 E1A1 { get; set; } = null!;

    [JsonProperty("e1a2")]
    public E1A2 E1A2 { get; set; } = null!;

    [JsonProperty("e1a3")]
    public E1A1 E1A3 { get; set; } = null!;

    [JsonProperty("e2a1")]
    public E1A2 E2A1 { get; set; } = null!;

    [JsonProperty("e2a2")]
    public E1A1 E2A2 { get; set; } = null!;

    [JsonProperty("e2a3")]
    public E1A2 E2A3 { get; set; } = null!;

    [JsonProperty("e3a1")]
    public E1A1 E3A1 { get; set; } = null!;

    [JsonProperty("e3a2")]
    public E1A2 E3A2 { get; set; } = null!;

    [JsonProperty("e3a3")]
    public E1A2 E3A3 { get; set; } = null!;

    [JsonProperty("e4a1")]
    public E1A2 E4A1 { get; set; } = null!;

    [JsonProperty("e4a2")]
    public E1A2 E4A2 { get; set; } = null!;

    [JsonProperty("e4a3")]
    public E1A2 E4A3 { get; set; } = null!;

    [JsonProperty("e5a1")]
    public E1A2 E5A1 { get; set; } = null!;

    [JsonProperty("e5a2")]
    public E1A1 E5A2 { get; set; } = null!;

    [JsonProperty("e5a3")]
    public E1A2 E5A3 { get; set; } = null!;

    [JsonProperty("e6a1")]
    public E1A2 E6A1 { get; set; } = null!;

    [JsonProperty("e6a2")]
    public E1A2 E6A2 { get; set; } = null!;

    [JsonProperty("e6a3")]
    public E1A2 E6A3 { get; set; } = null!;

    [JsonProperty("e7a1")]
    public E1A1 E7A1 { get; set; } = null!;

    [JsonProperty("e7a2")]
    public E1A1 E7A2 { get; set; } = null!;

    [JsonProperty("e7a3")]
    public E1A1 E7A3 { get; set; } = null!;

    [JsonProperty("e8a1")]
    public E1A1 E8A1 { get; set; } = null!;

    [JsonProperty("e8a2")]
    public E1A2 E8A2 { get; set; } = null!;

    [JsonProperty("e8a3")]
    public E1A2 E8A3 { get; set; } = null!;
}

public partial class E1A1
{
    [JsonProperty("error")]
    public string Error { get; set; } = null!;
}

public partial class E1A2
{
    [JsonProperty("wins")]
    public long Wins { get; set; }

    [JsonProperty("number_of_games")]
    public long NumberOfGames { get; set; }

    [JsonProperty("final_rank")]
    public long FinalRank { get; set; }

    [JsonProperty("final_rank_patched")]
    public string FinalRankPatched { get; set; } = null!;

    [JsonProperty("act_rank_wins")]
    public ActRankWin[] ActRankWins { get; set; } = null!;

    [JsonProperty("old")]
    public bool Old { get; set; }
}

public partial class ActRankWin
{
    [JsonProperty("patched_tier")]
    public string PatchedTier { get; set; } = null!;

    [JsonProperty("tier")]
    public long Tier { get; set; }
}

public partial class CurrentData
{
    [JsonProperty("currenttier")]
    public long Currenttier { get; set; }

    [JsonProperty("currenttierpatched")]
    public string Currenttierpatched { get; set; } = null!;

    [JsonProperty("images")]
    public Images Images { get; set; } = null!;

    [JsonProperty("ranking_in_tier")]
    public long RankingInTier { get; set; }

    [JsonProperty("mmr_change_to_last_game")]
    public long MmrChangeToLastGame { get; set; }

    [JsonProperty("elo")]
    public long Elo { get; set; }

    [JsonProperty("games_needed_for_rating")]
    public long GamesNeededForRating { get; set; }

    [JsonProperty("old")]
    public bool Old { get; set; }
}

public partial class Images
{
    [JsonProperty("small")]
    public Uri Small { get; set; } = null!;

    [JsonProperty("large")]
    public Uri Large { get; set; } = null!;

    [JsonProperty("triangle_down")]
    public Uri TriangleDown { get; set; } = null!;

    [JsonProperty("triangle_up")]
    public Uri TriangleUp { get; set; } = null!;
}

public partial class HighestRank
{
    [JsonProperty("old")]
    public bool Old { get; set; }

    [JsonProperty("tier")]
    public long Tier { get; set; }

    [JsonProperty("patched_tier")]
    public string PatchedTier { get; set; } = null!;

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