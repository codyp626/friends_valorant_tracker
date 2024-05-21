using FriendsTracker.Components.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace FriendsTracker.Components.Pages;

public partial class Matches
{
    [Parameter]
    public string puuid { get; set; } = "";

    public MatchResponse? matchResponse = null;

    public string display = "";

    protected override async Task OnInitializedAsync()
    {
        // Console.WriteLine("matches page loaded");
        matchResponse = await GetMatchesMongo();
        foreach (var match in matchResponse.Data)
        {
            display += match.Metadata.Map;
            display += match.Metadata.RoundsPlayed + "rounds";
        }
    }

    public async Task<MatchResponse?> GetMatchesMongo()
    {
        MatchResponse matches = null;
        var client = new MongoClient(Program.connectionString);
        var collection = client.GetDatabase("player_data_db").GetCollection<MatchResponse>("matches");

        var filter = Builders<MatchResponse>.Filter.Eq("puuid", puuid);
        try
        {
            matches = await collection.Find(filter).SingleOrDefaultAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("failed to get mongo data Error: " + ex.Message);
        }
        return matches;
    }
}