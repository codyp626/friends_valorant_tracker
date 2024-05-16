using MediatR;
using Microsoft.AspNetCore.Components;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using FriendsTracker.Components.Infrastructure;
using DnsClient.Protocol;
using ZstdSharp.Unsafe;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FriendsTracker.Components.Pages;

public partial class Ranks
{
    protected override async Task OnInitializedAsync()
    {
        rankList = await getMongoRanks("player_data_db", "rank");
        rankList = rankList.OrderByDescending(r => r.Data.CurrentData.Elo).ToList();
    }

    public List<GetRankResponse> rankList = new();
    private bool _isLoading;


    public IMongoDatabase GetDatabase(string databaseName)
    {
        var connectionString = $"mongodb+srv://brewt:{Program.mongoKey}@cluster0.xpbkg6w.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        var client = new MongoClient(connectionString);
        return client.GetDatabase(databaseName);
    }

    public async Task<List<GetRankResponse>> getMongoRanks(string databaseName, string collectionName)
    {
        var list = new List<GetRankResponse>();
        var collection = GetDatabase(databaseName).GetCollection<BsonDocument>(collectionName);
        var filter = Builders<BsonDocument>.Filter.Empty; // Empty filter to match all documents
        try
        {
            var queryableCollection = await collection.AsQueryable().ToListAsync();

            //doc count for testing
            Console.WriteLine("DOCUMENT count:" + collection.CountDocuments(filter));
            foreach (BsonDocument bson_rank in queryableCollection)
            {
                GetRankResponse rank = BsonSerializer.Deserialize<GetRankResponse>(bson_rank);
                list.Add(rank);
                // rankList.Add(rank);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while listing data from collection {collectionName}: {ex.Message}");
        }

        Console.WriteLine("list count: " + list.Count);
        return list;
    }

    // public void ButtonFunction()
    // {
    //     // rankList = await getPlayerRank();
    // }


    public async Task updateMongoRanks()
    {
        var database = GetDatabase("player_data_db");
        var collection = database.GetCollection<GetRankResponse>("rank");
        var updatedRanks = await getPlayerRanksHTTP();
        foreach(GetRankResponse player in updatedRanks)
        {
            var filter = Builders<GetRankResponse>.Filter.Eq(r => r.Data.Name, player.Data.Name);
            var update = Builders<GetRankResponse>.Update.Set(r => r.Data, player.Data);
            var result = await collection.UpdateOneAsync(filter, update);
            Console.WriteLine(result.ToString());
        }
        // ButtonFunction(); //update data to the viewer
    }



    public async Task<List<GetRankResponse>> getPlayerRanksHTTP()
    {
        var players = new List<string>() {"Jsav16/9925", "cadennedac/na1", "augdog922/2884", "mingemuncher14/misa", "BootyConsumer/376", "Brewt/0000", "Stroup22/na1", "WildKevDog/house"};
        // var players = new List<string>() { "BootyConsumer/376", "Brewt/0000" };
        var ranks = new List<GetRankResponse>();

        static async Task<GetRankResponse?> ProcessRepositoriesAsync(HttpClient client, string player)
        {
            var json = await client.GetStringAsync($"https://api.henrikdev.xyz/valorant/v2/mmr/na/{player}");
            GetRankResponse? rank = GetRankResponse.FromJson(json);
            if (rank is null)
            {
                Console.WriteLine("API ERROR");
                return null;
            }
            else
            {
                return rank;
            }
        }

        foreach (var player in players)
        {
            Console.WriteLine($"starting on {player}");
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authentication", Program.henrik_API_Key);
            var rank = await ProcessRepositoriesAsync(client, player);
            if (rank is not null)
            {
                ranks.Add(rank);
            }
        }

        return ranks;
    }
}