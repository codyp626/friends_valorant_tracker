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

namespace FriendsTracker.Components.Pages;

public partial class Ranks
{
    public List<GetRankResponse> rankList = new();
    private int bullshit = 0;
    private bool _isLoading;


    public IMongoDatabase GetDatabase(string databaseName)
    {
        var connectionString = $"mongodb+srv://brewt:{Program.mongoKey}@cluster0.xpbkg6w.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        var client = new MongoClient(connectionString);
        return client.GetDatabase(databaseName);
    }

    public List<GetRankResponse> ListAllData(string databaseName, string collectionName)
    {
        var list = new List<GetRankResponse>();
        var collection = GetDatabase(databaseName).GetCollection<BsonDocument>(collectionName);
        var filter = Builders<BsonDocument>.Filter.Empty; // Empty filter to match all documents
        try
        {
            var queryableCollection = collection.AsQueryable().AsEnumerable();

            //doc count for testing
            Console.WriteLine("DOCUMENT count:" + collection.CountDocuments(filter));
            foreach (BsonDocument bson_rank in queryableCollection) 
            {
                GetRankResponse rank = BsonSerializer.Deserialize<GetRankResponse>(bson_rank);
                // Console.WriteLine("RANK OBJECT:" + rank.ToJson());
                // Console.WriteLine("FOUND DOCUMENT");
                list.Add(rank);
            }
            // Console.WriteLine("RANK OBJECT:" + rank.Data.Name + rank.Data.CurrentData.Currenttierpatched);
            // rankList = rank.Data.Name + " is " + rank.Data.CurrentData.Currenttierpatched;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while listing data from collection {collectionName}: {ex.Message}");
        }
        
        Console.WriteLine("list count: " + list.Count);
        return list;
    }

    public void ButtonFunction()
    {
        rankList = ListAllData("player_data_db", "rank");
        rankList = rankList.OrderByDescending(r => r.Data.CurrentData.Elo).ToList();
    }


    public void updateRanks()
    {
        var database = GetDatabase("player_data_db");
        var collection = database.GetCollection<BsonDocument>("rank");
        var filter = Builders<GetRankResponse>.Filter.Eq(r => r.Data.Name, "Brewt");
        // TODO update ranks on button press
        // var update = Builders<GetRankResponse>.Update.Set(r => r.Data, new GetRankResponse );
    }

    public GetRankResponse getPlayerRank(string name, string tag)
    {
        return null;
    }

        public async Task<List<GetRankResponse>> getPlayerRank()
    {
        // var players = new List<string>() {"Jsav16/9925", "cadennedac/na1", "augdog922/2884", "mingemuncher14/misa", "BootyConsumer/376", "Brewt/0000", "Stroup22/na1", "WildKevDog/house"};
        var players = new List<string>() {"BootyConsumer/376", "Brewt/0000"};
        var ranks = new List<GetRankResponse>();

        foreach (var player in players)
        {


            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("apikey"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            await ProcessRepositoriesAsync(client);

            static async Task ProcessRepositoriesAsync(HttpClient client)
            {
            }
        }

        return ranks;
    }
}