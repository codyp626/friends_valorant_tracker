
using MongoDB.Bson.Serialization.Attributes;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FriendsTracker.Components.Infrastructure;




//UNUSED AT THE MOMENT
[BsonIgnoreExtraElements]
public partial class MatchResponse
{

    [JsonProperty("status")]
    [BsonElement("status")]
    public long Status { get; set; }

    [JsonProperty("data")]
    [BsonElement("data")]
    public MatchArray[]? Data { get; set; }

    [JsonProperty("puuid")]
    [BsonElement("puuid")]
    public string? puuid { get; set; }
}

public partial class MatchArray
{
    [JsonProperty("is_available")]
    [BsonElement("is_available")]
    public bool IsAvailable { get; set; }

    [JsonProperty("metadata")]
    [BsonElement("metadata")]
    public Metadata? Metadata { get; set; }

    [JsonProperty("players")]
    [BsonElement("players")]
    public Players? Players { get; set; }

    [JsonProperty("observers")]
    [BsonElement("observers")]
    public object[]? Observers { get; set; }

    [JsonProperty("coaches")]
    [BsonElement("coaches")]
    public object[]? Coaches { get; set; }

    [JsonProperty("teams")]
    [BsonElement("teams")]
    public Teams? Teams { get; set; }

    [JsonProperty("rounds")]
    [BsonElement("rounds")]
    public Round[]? Rounds { get; set; }

    [JsonProperty("kills")]
    [BsonElement("kills")]
    public Kill[]? Kills { get; set; }
}

public partial class Kill
{
    [JsonProperty("kill_time_in_round")]
    [BsonElement("kill_time_in_round")]
    public long KillTimeInRound { get; set; }

    [JsonProperty("kill_time_in_match")]
    [BsonElement("kill_time_in_match")]
    public long KillTimeInMatch { get; set; }

    [JsonProperty("round")]
    [BsonElement("round")]
    public long? Round { get; set; }

    [JsonProperty("killer_puuid")]
    [BsonElement("killer_puuid")]
    public Guid KillerPuuid { get; set; }

    [JsonProperty("killer_display_name")]
    [BsonElement("killer_display_name")]
    public string? KillerDisplayName { get; set; }

    [JsonProperty("killer_team")]
    [BsonElement("killer_team")]
    public string? KillerTeam { get; set; }

    [JsonProperty("victim_puuid")]
    [BsonElement("victim_puuid")]
    public Guid VictimPuuid { get; set; }

    [JsonProperty("victim_display_name")]
    [BsonElement("victim_display_name")]
    public string? VictimDisplayName { get; set; }

    [JsonProperty("victim_team")]
    [BsonElement("victim_team")]
    public string? VictimTeam { get; set; }

    [JsonProperty("victim_death_location")]
    [BsonElement("victim_death_location")]
    public Location? VictimDeathLocation { get; set; }

    [JsonProperty("damage_weapon_id")]
    [BsonElement("damage_weapon_id")]
    public string? DamageWeaponId { get; set; }

    [JsonProperty("damage_weapon_name")]
    [BsonElement("damage_weapon_name")]
    public string? DamageWeaponName { get; set; }

    [JsonProperty("damage_weapon_assets")]
    [BsonElement("damage_weapon_assets")]
    public DamageWeaponAssetsClass? DamageWeaponAssets { get; set; }

    [JsonProperty("secondary_fire_mode")]
    [BsonElement("secondary_fire_mode")]
    public bool SecondaryFireMode { get; set; }

    [JsonProperty("player_locations_on_kill")]
    [BsonElement("player_locations_on_kill")]
    public PlayerLocationsOn[]? PlayerLocationsOnKill { get; set; }

    [JsonProperty("assistants")]
    [BsonElement("assistants")]
    public Assistant[]? Assistants { get; set; }
}

public partial class Assistant
{
    [JsonProperty("assistant_puuid")]
    [BsonElement("assistant_puuid")]
    public Guid AssistantPuuid { get; set; }

    [JsonProperty("assistant_display_name")]
    [BsonElement("assistant_display_name")]
    public string? AssistantDisplayName { get; set; }

    [JsonProperty("assistant_team")]
    [BsonElement("assistant_team")]
    public string? AssistantTeam { get; set; }
}

public partial class DamageWeaponAssetsClass
{
    [JsonProperty("display_icon")]
    [BsonElement("display_icon")]
    public Uri? DisplayIcon { get; set; }

    [JsonProperty("killfeed_icon")]
    [BsonElement("killfeed_icon")]
    public Uri? KillfeedIcon { get; set; }
}

public partial class PlayerLocationsOn
{
    [JsonProperty("player_puuid")]
    [BsonElement("player_puuid")]
    public Guid PlayerPuuid { get; set; }

    [JsonProperty("player_display_name")]
    [BsonElement("player_display_name")]
    public string? PlayerDisplayName { get; set; }

    [JsonProperty("player_team")]
    [BsonElement("player_team")]
    public string? PlayerTeam { get; set; }

    [JsonProperty("location")]
    [BsonElement("location")]
    public Location? Location { get; set; }

    [JsonProperty("view_radians")]
    [BsonElement("view_radians")]
    public double ViewRadians { get; set; }
}

public partial class Location
{
    [JsonProperty("x")]
    [BsonElement("x")]
    public long X { get; set; }

    [JsonProperty("y")]
    [BsonElement("y")]
    public long Y { get; set; }
}

public partial class Metadata
{
    [JsonProperty("map")]
    [BsonElement("map")]
    public string? Map { get; set; }

    [JsonProperty("game_version")]
    [BsonElement("game_version")]
    public string? GameVersion { get; set; }

    [JsonProperty("game_length")]
    [BsonElement("game_length")]
    public long GameLength { get; set; }

    [JsonProperty("game_start")]
    [BsonElement("game_start")]
    public long GameStart { get; set; }

    [JsonProperty("game_start_patched")]
    [BsonElement("game_start_patched")]
    public string? GameStartPatched { get; set; }

    [JsonProperty("rounds_played")]
    [BsonElement("rounds_played")]
    public long RoundsPlayed { get; set; }

    [JsonProperty("mode")]
    [BsonElement("mode")]
    public string? Mode { get; set; }

    [JsonProperty("mode_id")]
    [BsonElement("mode_id")]
    public string? ModeId { get; set; }

    [JsonProperty("queue")]
    [BsonElement("queue")]
    public string? Queue { get; set; }

    [JsonProperty("season_id")]
    [BsonElement("season_id")]
    public Guid SeasonId { get; set; }

    [JsonProperty("platform")]
    [BsonElement("platform")]
    public string? Platform { get; set; }

    [JsonProperty("matchid")]
    [BsonElement("matchid")]
    public Guid Matchid { get; set; }

    [JsonProperty("premier_info")]
    [BsonElement("premier_info")]
    public PremierInfo? PremierInfo { get; set; }

    [JsonProperty("region")]
    [BsonElement("region")]
    public string? Region { get; set; }

    [JsonProperty("cluster")]
    [BsonElement("cluster")]
    public string? Cluster { get; set; }
}

public partial class PremierInfo
{
    [JsonProperty("tournament_id")]
    [BsonElement("tournament_id")]
    public object? TournamentId { get; set; }

    [JsonProperty("matchup_id")]
    [BsonElement("matchup_id")]
    public object? MatchupId { get; set; }
}

public partial class Players
{
    [JsonProperty("all_players")]
    [BsonElement("all_players")]
    public AllPlayer[]? AllPlayers { get; set; }

    [JsonProperty("red")]
    [BsonElement("red")]
    public AllPlayer[]? Red { get; set; }

    [JsonProperty("blue")]
    [BsonElement("blue")]
    public AllPlayer[]? Blue { get; set; }
}

public partial class AllPlayer
{
    [JsonProperty("puuid")]
    [BsonElement("puuid")]
    public Guid Puuid { get; set; }

    [JsonProperty("name")]
    [BsonElement("name")]
    public string? Name { get; set; }

    [JsonProperty("tag")]
    [BsonElement("tag")]
    public string? Tag { get; set; }

    [JsonProperty("team")]
    [BsonElement("team")]
    public string? Team { get; set; }

    [JsonProperty("level")]
    [BsonElement("level")]
    public long Level { get; set; }

    [JsonProperty("character")]
    [BsonElement("character")]
    public string? Character { get; set; }

    [JsonProperty("currenttier")]
    [BsonElement("currenttier")]
    public long Currenttier { get; set; }

    [JsonProperty("currenttier_patched")]
    [BsonElement("currenttier_patched")]
    public string? CurrenttierPatched { get; set; }

    [JsonProperty("player_card")]
    [BsonElement("player_card")]
    public Guid PlayerCard { get; set; }

    [JsonProperty("player_title")]
    [BsonElement("player_title")]
    public Guid PlayerTitle { get; set; }

    [JsonProperty("party_id")]
    [BsonElement("party_id")]
    public Guid PartyId { get; set; }

    [JsonProperty("session_playtime")]
    [BsonElement("session_playtime")]
    public SessionPlaytime? SessionPlaytime { get; set; }

    [JsonProperty("behavior")]
    [BsonElement("behavior")]
    public Behavior? Behavior { get; set; }

    [JsonProperty("platform")]
    [BsonElement("platform")]
    public PlatformClass? Platform { get; set; }

    [JsonProperty("ability_casts")]
    [BsonElement("ability_casts")]
    public AllPlayerAbilityCasts? AbilityCasts { get; set; }

    [JsonProperty("assets")]
    [BsonElement("assets")]
    public AllPlayerAssets? Assets { get; set; }

    [JsonProperty("stats")]
    [BsonElement("stats")]
    public Stats? Stats { get; set; }

    [JsonProperty("economy")]
    [BsonElement("economy")]
    public AllPlayerEconomy? Economy { get; set; }

    [JsonProperty("damage_made")]
    [BsonElement("damage_made")]
    public long DamageMade { get; set; }

    [JsonProperty("damage_received")]
    [BsonElement("damage_received")]
    public long DamageReceived { get; set; }
}

public partial class AllPlayerAbilityCasts
{
    [JsonProperty("c_cast")]
    [BsonElement("c_cast")]
    public long CCast { get; set; }

    [JsonProperty("q_cast")]
    [BsonElement("q_cast")]
    public long QCast { get; set; }

    [JsonProperty("e_cast")]
    [BsonElement("e_cast")]
    public long ECast { get; set; }

    [JsonProperty("x_cast")]
    [BsonElement("x_cast")]
    public long XCast { get; set; }
}

public partial class AllPlayerAssets
{
    [JsonProperty("card")]
    [BsonElement("card")]
    public Card? Card { get; set; }

    [JsonProperty("agent")]
    [BsonElement("agent")]
    public Agent? Agent { get; set; }
}

public partial class Agent
{
    [JsonProperty("small")]
    [BsonElement("small")]
    public Uri? Small { get; set; }

    [JsonProperty("bust")]
    [BsonElement("bust")]
    public Uri? Bust { get; set; }

    [JsonProperty("full")]
    [BsonElement("full")]
    public Uri? Full { get; set; }

    [JsonProperty("killfeed")]
    [BsonElement("killfeed")]
    public Uri? Killfeed { get; set; }
}

public partial class Card
{
    [JsonProperty("small")]
    [BsonElement("small")]
    public Uri? Small { get; set; }

    [JsonProperty("large")]
    [BsonElement("large")]
    public Uri? Large { get; set; }

    [JsonProperty("wide")]
    [BsonElement("wide")]
    public Uri? Wide { get; set; }
}

public partial class Behavior
{
    [JsonProperty("afk_rounds")]
    [BsonElement("afk_rounds")]
    public double AfkRounds { get; set; }

    [JsonProperty("friendly_fire")]
    [BsonElement("friendly_fire")]
    public FriendlyFire? FriendlyFire { get; set; }

    [JsonProperty("rounds_in_spawn")]
    [BsonElement("rounds_in_spawn")]
    public double RoundsInSpawn { get; set; }
}

public partial class FriendlyFire
{
    [JsonProperty("incoming")]
    [BsonElement("incoming")]
    public long Incoming { get; set; }

    [JsonProperty("outgoing")]
    [BsonElement("outgoing")]
    public long Outgoing { get; set; }
}

public partial class AllPlayerEconomy
{
    [JsonProperty("spent")]
    [BsonElement("spent")]
    public LoadoutValue? Spent { get; set; }

    [JsonProperty("loadout_value")]
    [BsonElement("loadout_value")]
    public LoadoutValue? LoadoutValue { get; set; }
}

public partial class LoadoutValue
{
    [JsonProperty("overall")]
    [BsonElement("overall")]
    public long Overall { get; set; }

    [JsonProperty("average")]
    [BsonElement("average")]
    public long Average { get; set; }
}

public partial class PlatformClass
{
    [JsonProperty("type")]
    [BsonElement("type")]
    public string? Type { get; set; }

    [JsonProperty("os")]
    [BsonElement("os")]
    public Os? Os { get; set; }
}

public partial class Os
{
    [JsonProperty("name")]
    [BsonElement("name")]
    public string? Name { get; set; }

    [JsonProperty("version")]
    [BsonElement("version")]
    public string? Version { get; set; }
}

public partial class SessionPlaytime
{
    [JsonProperty("minutes")]
    [BsonElement("minutes")]
    public long Minutes { get; set; }

    [JsonProperty("seconds")]
    [BsonElement("seconds")]
    public long Seconds { get; set; }

    [JsonProperty("milliseconds")]
    [BsonElement("milliseconds")]
    public long Milliseconds { get; set; }
}

public partial class Stats
{
    [JsonProperty("score")]
    [BsonElement("score")]
    public long Score { get; set; }

    [JsonProperty("kills")]
    [BsonElement("kills")]
    public long Kills { get; set; }

    [JsonProperty("deaths")]
    [BsonElement("deaths")]
    public long Deaths { get; set; }

    [JsonProperty("assists")]
    [BsonElement("assists")]
    public long Assists { get; set; }

    [JsonProperty("bodyshots")]
    [BsonElement("bodyshots")]
    public long Bodyshots { get; set; }

    [JsonProperty("headshots")]
    [BsonElement("headshots")]
    public long Headshots { get; set; }

    [JsonProperty("legshots")]
    [BsonElement("legshots")]
    public long Legshots { get; set; }
}

public partial class Round
{
    [JsonProperty("winning_team")]
    [BsonElement("winning_team")]
    public string? WinningTeam { get; set; }

    [JsonProperty("end_type")]
    [BsonElement("end_type")]
    public string? EndType { get; set; }

    [JsonProperty("bomb_planted")]
    [BsonElement("bomb_planted")]
    public bool BombPlanted { get; set; }

    [JsonProperty("bomb_defused")]
    [BsonElement("bomb_defused")]
    public bool BombDefused { get; set; }

    [JsonProperty("plant_events")]
    [BsonElement("plant_events")]
    public PlantEvents? PlantEvents { get; set; }

    [JsonProperty("defuse_events")]
    [BsonElement("defuse_events")]
    public DefuseEvents? DefuseEvents { get; set; }

    [JsonProperty("player_stats")]
    [BsonElement("player_stats")]
    public PlayerStat[]? PlayerStats { get; set; }
}

public partial class DefuseEvents
{
    [JsonProperty("defuse_location")]
    [BsonElement("defuse_location")]
    public Location? DefuseLocation { get; set; }

    [JsonProperty("defused_by")]
    [BsonElement("defused_by")]
    public EdBy? DefusedBy { get; set; }

    [JsonProperty("defuse_time_in_round")]
    [BsonElement("defuse_time_in_round")]
    public long? DefuseTimeInRound { get; set; }

    [JsonProperty("player_locations_on_defuse")]
    [BsonElement("player_locations_on_defuse")]
    public PlayerLocationsOn[]? PlayerLocationsOnDefuse { get; set; }
}

public partial class EdBy
{
    [JsonProperty("puuid")]
    [BsonElement("puuid")]
    public Guid Puuid { get; set; }

    [JsonProperty("display_name")]
    [BsonElement("display_name")]
    public string? DisplayName { get; set; }

    [JsonProperty("team")]
    [BsonElement("team")]
    public string? Team { get; set; }
}

public partial class PlantEvents
{
    [JsonProperty("plant_location")]
    [BsonElement("plant_location")]
    public Location? PlantLocation { get; set; }

    [JsonProperty("planted_by")]
    [BsonElement("planted_by")]
    public EdBy? PlantedBy { get; set; }

    [JsonProperty("plant_site")]
    [BsonElement("plant_site")]
    public string? PlantSite { get; set; }

    [JsonProperty("plant_time_in_round")]
    [BsonElement("plant_time_in_round")]
    public long? PlantTimeInRound { get; set; }

    [JsonProperty("player_locations_on_plant")]
    [BsonElement("player_locations_on_plant")]
    public PlayerLocationsOn[]? PlayerLocationsOnPlant { get; set; }
}

public partial class PlayerStat
{
    [JsonProperty("ability_casts")]
    [BsonElement("ability_casts")]
    public PlayerStatAbilityCasts? AbilityCasts { get; set; }

    [JsonProperty("player_puuid")]
    [BsonElement("player_puuid")]
    public Guid PlayerPuuid { get; set; }

    [JsonProperty("player_display_name")]
    [BsonElement("player_display_name")]
    public string? PlayerDisplayName { get; set; }

    [JsonProperty("player_team")]
    [BsonElement("player_team")]
    public string? PlayerTeam { get; set; }

    [JsonProperty("damage_events")]
    [BsonElement("damage_events")]
    public DamageEvent[]? DamageEvents { get; set; }

    [JsonProperty("damage")]
    [BsonElement("damage")]
    public long Damage { get; set; }

    [JsonProperty("bodyshots")]
    [BsonElement("bodyshots")]
    public long Bodyshots { get; set; }

    [JsonProperty("headshots")]
    [BsonElement("headshots")]
    public long Headshots { get; set; }

    [JsonProperty("legshots")]
    [BsonElement("legshots")]
    public long Legshots { get; set; }

    [JsonProperty("kill_events")]
    [BsonElement("kill_events")]
    public Kill[]? KillEvents { get; set; }

    [JsonProperty("kills")]
    [BsonElement("kills")]
    public long Kills { get; set; }

    [JsonProperty("score")]
    [BsonElement("score")]
    public long Score { get; set; }

    [JsonProperty("economy")]
    [BsonElement("economy")]
    public PlayerStatEconomy? Economy { get; set; }

    [JsonProperty("was_afk")]
    [BsonElement("was_afk")]
    public bool WasAfk { get; set; }

    [JsonProperty("was_penalized")]
    [BsonElement("was_penalized")]
    public bool WasPenalized { get; set; }

    [JsonProperty("stayed_in_spawn")]
    [BsonElement("stayed_in_spawn")]
    public bool StayedInSpawn { get; set; }
}

public partial class PlayerStatAbilityCasts
{
    [JsonProperty("c_casts")]
    [BsonElement("c_casts")]
    public object? CCasts { get; set; }

    [JsonProperty("q_casts")]
    [BsonElement("q_casts")]
    public object? QCasts { get; set; }

    [JsonProperty("e_cast")]
    [BsonElement("e_cast")]
    public object? ECast { get; set; }

    [JsonProperty("x_cast")]
    [BsonElement("x_cast")]
    public object? XCast { get; set; }
}

public partial class DamageEvent
{
    [JsonProperty("receiver_puuid")]
    [BsonElement("receiver_puuid")]
    public Guid ReceiverPuuid { get; set; }

    [JsonProperty("receiver_display_name")]
    [BsonElement("receiver_display_name")]
    public string? ReceiverDisplayName { get; set; }

    [JsonProperty("receiver_team")]
    [BsonElement("receiver_team")]
    public string? ReceiverTeam { get; set; }

    [JsonProperty("bodyshots")]
    [BsonElement("bodyshots")]
    public long Bodyshots { get; set; }

    [JsonProperty("damage")]
    [BsonElement("damage")]
    public long Damage { get; set; }

    [JsonProperty("headshots")]
    [BsonElement("headshots")]
    public long Headshots { get; set; }

    [JsonProperty("legshots")]
    [BsonElement("legshots")]
    public long Legshots { get; set; }
}

public partial class PlayerStatEconomy
{
    [JsonProperty("loadout_value")]
    [BsonElement("loadout_value")]
    public long LoadoutValue { get; set; }

    [JsonProperty("weapon")]
    [BsonElement("weapon")]
    public Weapon? Weapon { get; set; }

    [JsonProperty("armor")]
    [BsonElement("armor")]
    public Armor? Armor { get; set; }

    [JsonProperty("remaining")]
    [BsonElement("remaining")]
    public long Remaining { get; set; }

    [JsonProperty("spent")]
    [BsonElement("spent")]
    public long Spent { get; set; }
}

[BsonIgnoreExtraElements]
public partial class Armor
{
    //TODO
    //for now screw the ID
    // [JsonProperty("id")]
    // [BsonElement("xid")]
    // public string Id { get; set; } = null!;

    [JsonProperty("name")]
    [BsonElement("name")]
    public string? Name { get; set; }

    [JsonProperty("assets")]
    [BsonElement("assets")]
    public ArmorAssets? Assets { get; set; }
}

public partial class ArmorAssets
{
    [JsonProperty("display_icon")]
    [BsonElement("display_icon")]
    public Uri? DisplayIcon { get; set; }
}

[BsonIgnoreExtraElements]
public partial class Weapon
{
    //TODO
    //for now screw the ID
    // [JsonProperty("id")]
    // [BsonElement("xid")]
    // public string? Id { get; set; }

    [JsonProperty("name")]
    [BsonElement("name")]
    public string? Name { get; set; }

    [JsonProperty("assets")]
    [BsonElement("assets")]
    public DamageWeaponAssetsClass? Assets { get; set; }
}

public partial class Teams
{
    [JsonProperty("red")]
    [BsonElement("red")]
    public Blue? Red { get; set; }

    [JsonProperty("blue")]
    [BsonElement("blue")]
    public Blue? Blue { get; set; }
}

public partial class Blue
{
    [JsonProperty("has_won")]
    [BsonElement("has_won")]
    public bool HasWon { get; set; }

    [JsonProperty("rounds_won")]
    [BsonElement("rounds_won")]
    public long RoundsWon { get; set; }

    [JsonProperty("rounds_lost")]
    [BsonElement("rounds_lost")]
    public long RoundsLost { get; set; }

    [JsonProperty("roster")]
    [BsonElement("roster")]
    public object? Roster { get; set; }
}

public partial class MatchResponse
{
    public static MatchResponse? FromJson(string json) => JsonConvert.DeserializeObject<MatchResponse>(json, Converter.Settings);
}

// public partial class MatchResponse
// {
//     public static MatchResponse FromJson(string json) => JsonConvert.DeserializeObject<MatchResponse>(json, Converter.Settings);
// }

// public static class Serialize
// {
//     public static string ToJson(this MatchResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
// }

// internal static class Converter
// {
//     public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
//     {
//         MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
//         DateParseHandling = DateParseHandling.None,
//     };
// }