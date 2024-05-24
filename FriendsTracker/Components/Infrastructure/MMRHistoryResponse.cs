

namespace FriendsTracker.Components.Infrastructure
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using MongoDB.Bson.Serialization.Attributes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [BsonIgnoreExtraElements]
    public partial class MMRHistoryResponse
    {
        [BsonElement("status")]
        public int? Status { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("tag")]
        public string? Tag { get; set; }

        [BsonElement("results")]
        public Results? Results { get; set; }

        [BsonElement("data")]
        public Datum[]? Data { get; set; }
    }

    public partial class Datum
    {
        [BsonElement("match_id")]
        public string? MatchId { get; set; }

        [BsonElement("tier")]
        public Tier? Tier { get; set; }

        [BsonElement("map")]
        public Map? Map { get; set; }

        [BsonElement("season")]
        public Season? Season { get; set; }

        [BsonElement("ranking_in_tier")]
        public int? RankingInTier { get; set; }

        [BsonElement("last_mmr_change")]
        public int? LastMmrChange { get; set; }

        [BsonElement("elo")]
        public int Elo { get; set; }

        [BsonElement("date")]
        public DateTimeOffset Date { get; set; }
    }

    [BsonIgnoreExtraElements]
    public partial class Map
    {
        [BsonElement("name")]
        public string? Name { get; set; }
    }
    
    [BsonIgnoreExtraElements]
    public partial class Season
    {
        [BsonElement("short")]
        public string? Short { get; set; }
    }

    [BsonIgnoreExtraElements]
    public partial class Tier
    {
        [BsonElement("name")]
        public string? Name { get; set; }
    }

    public partial class Results
    {
        [BsonElement("total")]
        public int? Total { get; set; }

        [BsonElement("returned")]
        public int? Returned { get; set; }

        [BsonElement("before")]
        public int? Before { get; set; }

        [BsonElement("after")]
        public int? After { get; set; }
    }

    public partial class MMRWrapper
    {
        public MMRHistory[]? mmrArray { get; set; }

        public MMRWrapper(MMRHistory[] mmrArray)
        {
            this.mmrArray = mmrArray;
        }
        
    }

    public partial class MMRHistory
    {
        public long DateOffset { get; set; }

        public int Elo { get; set; }

        public MMRHistory(long DateOffset, int Elo)
        {
            this.Elo = Elo;
            this.DateOffset = DateOffset;
        }

    }

    public partial class MMRHistoryResponse
    {
        public static MMRHistoryResponse? FromJson(string json) => JsonConvert.DeserializeObject<MMRHistoryResponse>(json, Converter.Settings);
    }
}