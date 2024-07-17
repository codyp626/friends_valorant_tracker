

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
		[JsonProperty("status")]
        public int Status { get; set; }

        [BsonElement("name")]
		[JsonProperty("name")]
        public string? Name { get; set; }

        [BsonElement("tag")]
		[JsonProperty("tag")]
        public string? Tag { get; set; }

        [BsonElement("data")]
		[JsonProperty("data")]
        public Datum[]? Data { get; set; }
    }

    public partial class Datum
    {
        [BsonElement("currenttier")]
		[JsonProperty("currenttier")]
        public int Currenttier { get; set; }

        [BsonElement("currenttierpatched")]
		[JsonProperty("currenttierpatched")]
        public string? Currenttierpatched { get; set; }

        [BsonElement("images")]
		[JsonProperty("images")]
        public Images? Images { get; set; }

        [BsonElement("match_id")]
		[JsonProperty("match_id")]
        public string? MatchId { get; set; }

        [BsonElement("map")]
		[JsonProperty("map")]
        public Map? Map { get; set; }

        [BsonElement("season_id")]
		[JsonProperty("season_id")]
        public string? SeasonId { get; set; }

        [BsonElement("ranking_in_tier")]
		[JsonProperty("ranking_in_tier")]
        public int RankingInTier { get; set; }

        [BsonElement("mmr_change_to_last_game")]
		[JsonProperty("mmr_change_to_last_game")]
        public int MmrChangeToLastGame { get; set; }

        [BsonElement("elo")]
		[JsonProperty("elo")]
        public int Elo { get; set; }

        [BsonElement("date")]
		[JsonProperty("date")]
        public string? Date { get; set; }

        [BsonElement("date_raw")]
		[JsonProperty("date_raw")]
        public int DateRaw { get; set; }
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
    

    public partial class MMRHistoryResponse
    {
        public static MMRHistoryResponse? FromJson(string json) => JsonConvert.DeserializeObject<MMRHistoryResponse>(json, Converter.Settings);
    }
}