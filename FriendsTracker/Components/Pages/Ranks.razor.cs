using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using FriendsTracker.Components.Infrastructure;
using System.Net.Http.Headers;

namespace FriendsTracker.Components.Pages;

public partial class Ranks : IDisposable
{
    private bool _isLoading = true;
    public List<GetRankResponse> rankList = new();

    public DateTime lastUpdated = DateTime.MinValue;
    private string timeSinceLastUpdated = "";
    private System.Timers.Timer timer = null!;

    protected override async Task OnInitializedAsync()
    {
        rankList = await getMongoRanksAsync("player_data_db", "rank");
        rankList = rankList.OrderByDescending(r => r.Data.CurrentData.Elo).ToList();
        _isLoading = false;
        await GetTimeAsync("rank");
        
        //Timer stuff
        UpdateTimeSinceLastUpdated();
        timer = new System.Timers.Timer(1000); // 1 second interval
        timer.Elapsed += (sender, e) => InvokeAsync(UpdateTimeSinceLastUpdated);
        timer.Start();
    }

    private void UpdateTimeSinceLastUpdated()
    {
        var timeSpan = DateTime.Now - lastUpdated;
        timeSinceLastUpdated = FormatTimeSpan(timeSpan);
        StateHasChanged(); // Notify the component to re-render
    }
    
    private string FormatTimeSpan(TimeSpan timeSpan)
    {
        string plural = "";
        if (timeSpan.TotalDays >= 1)
        {
            if (timeSpan.TotalDays >= 2)
                plural = "s";
            return $"{(int)timeSpan.TotalDays} day{plural} ago";
        }
        if (timeSpan.TotalHours >= 1)
        {
            if (timeSpan.TotalHours >= 2)
                plural = "s";
            return $"{(int)timeSpan.TotalHours} hour{plural} ago";
        }

        if (timeSpan.TotalMinutes >= 1)
        {
            if (timeSpan.TotalMinutes >= 2)
                plural = "s";
            return $"{(int)timeSpan.TotalMinutes} minute{plural} ago";
        }
        return $"{(int)timeSpan.TotalSeconds} seconds ago";
    }

    public void Dispose()
    {
        timer?.Dispose();
    }

    public IMongoDatabase GetDatabase(string databaseName)
    {
        var connectionString = $"mongodb+srv://brewt:{Program.mongoKey}@cluster0.xpbkg6w.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        var client = new MongoClient(connectionString);
        return client.GetDatabase(databaseName);
    }

    public async Task<List<GetRankResponse>> getMongoRanksAsync(string databaseName, string collectionName)
    {
        var list = new List<GetRankResponse>();
        var collection = GetDatabase(databaseName).GetCollection<BsonDocument>(collectionName);
        var filter = Builders<BsonDocument>.Filter.Empty; // Empty filter to match all documents
        try
        {
            var queryableCollection = await collection.AsQueryable().ToListAsync();
            foreach (BsonDocument bson_rank in queryableCollection)
            {
                GetRankResponse rank = BsonSerializer.Deserialize<GetRankResponse>(bson_rank);
                list.Add(rank);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while listing data from collection {collectionName}: {ex.Message}");
        }
        return list;
    }

    public async Task GetTimeAsync(string dataType)
    {
        var database = GetDatabase("player_data_db");
        var collection = database.GetCollection<CustomDate>("time_updated");
        var filter = Builders<CustomDate>.Filter.Eq(r => r.dataType, dataType); //match rank date type
        var time = await collection.AsQueryable().FirstAsync();
        lastUpdated = DateTime.FromBinary(time.dateBinary);
    }

    public async Task updateTimeAsync(IMongoDatabase database)
    {
        Console.WriteLine("starting updateTime");
        
        var collection = database.GetCollection<CustomDate>("time_updated");
        var currentTime = DateTime.Now;
        
        var filter = Builders<CustomDate>.Filter.Eq(r => r.dataType, "rank"); //match rank date type
        var update = Builders<CustomDate>.Update.Set(r => r.dateBinary, currentTime.ToBinary());
        await collection.UpdateOneAsync(filter, update);
        update = Builders<CustomDate>.Update.Set(r => r.dateString, currentTime.ToString());
        await collection.UpdateOneAsync(filter, update);
    }

    public async Task updateMongoRanksAsync()
    {
        _isLoading = true;
        var database = GetDatabase("player_data_db");
        await updateTimeAsync(database);
        var collection = database.GetCollection<GetRankResponse>("rank");
        var updatedRanks = await getPlayerRanksHTTPAsync();
        foreach(GetRankResponse player in updatedRanks)
        {
            //this filter should be puuid in the future
            var filter = Builders<GetRankResponse>.Filter.Eq(r => r.Data.Name, player.Data.Name);
            var update = Builders<GetRankResponse>.Update.Set(r => r.Data, player.Data);
            var result = await collection.UpdateOneAsync(filter, update);
        }
        await OnInitializedAsync();
    }

    public async Task<List<GetRankResponse>> getPlayerRanksHTTPAsync()
    {
        var players = new List<string>() {"Jsav16/9925", "cadennedac/na1", "augdog922/2884", "mingemuncher14/misa", "BootyConsumer/376", "Brewt/0000", "Stroup22/na1", "WildKevDog/house"};
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
            Console.Write($"getting {player}'s rank ...");
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", Program.henrik_API_Key);
            var rank = await ProcessRepositoriesAsync(client, player);
            if (rank is not null)
            {
                Console.WriteLine(" DONE");
                ranks.Add(rank);
            }
        }

        return ranks;
    }
}