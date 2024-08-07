
using MongoDB.Driver;
using FriendsTracker.Components.Infrastructure;
using System.Net.Http.Headers;
using Microsoft.JSInterop;
using MongoDB.Driver.Linq;

namespace FriendsTracker.Components.Pages;

public partial class Ranks : IDisposable
{
    private bool _isLoading = true;
    public List<GetRankResponse> rankList = new();

    public List<String> playerNames = new List<string>() 
    { 
        "shua/9731", 
        "spit%20slurpin/2222", 
        "Pepp/fishi", 
        "ZeroTwo/2809", 
        "Jsav16/9925", 
        "cadennedac/na1", 
        "augdog922/2884", 
        "mingemuncher14/misa", 
        "BootyConsumer/376", 
        "Brewt/0000", 
        "Stroup22/na1", 
        "WildKevDog/house" 
    };

    public DateTime lastUpdated = DateTime.MinValue;
    private string timeSinceLastUpdated = "";
    private System.Timers.Timer timer = null!;

    protected override async Task OnInitializedAsync()
    {
        await getMongoRanksAsync("player_data_db", "rank_test");
        rankList = rankList.OrderByDescending(r => r.Data.CurrentData.Elo).ToList();

        //Timer stuff
        await GetTimeAsync("rank");
        UpdateTimeSinceLastUpdated();
        timer = new System.Timers.Timer(1000); // 1 second interval
        timer.Elapsed += (sender, e) => InvokeAsync(UpdateTimeSinceLastUpdated);
        timer.Start();

        _isLoading = false;
        await displayGraphs();
        StateHasChanged();
    }

    private async Task displayGraphs()
    {


        foreach (var rank in rankList)
        {
            StateHasChanged();
            if(rank.Data.MMR.Data == null)
            {
                Console.WriteLine("ERROR: eloArray or dateArray JS array is null");
                return;
            }
            var eloArray =  rank.Data.MMR.Data.Where(d=> d.Elo != 0 && d.SeasonId == "52ca6698-41c1-e7de-4008-8994d2221209").Select(d => d.Elo).Reverse().ToArray();
            var dateArray = rank.Data.MMR.Data.Where(d=> d.Elo != 0).Select(d => DateTimeOffset.Parse(d.Date).ToUnixTimeSeconds()).Reverse().ToArray();
            
            await JSRuntime.InvokeVoidAsync("mmrChart", eloArray, dateArray, rank.Data.Puuid);
        }
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

    public void buttonFunc()
    {
        _isLoading = true;

        Console.WriteLine("loading...");
        StateHasChanged();
        Thread.Sleep(5);
        // _isLoading = false;
    }

    public void Dispose()
    {
        timer?.Dispose();
    }

    public IMongoDatabase GetDatabase(string databaseName)
    {
        var client = new MongoClient(Program.connectionString);
        return client.GetDatabase(databaseName);
    }

    public async Task getMongoRanksAsync(string databaseName, string collectionName)
    {
        rankList = new();
        var collection = GetDatabase(databaseName).GetCollection<GetRankResponse>(collectionName);
        try
        {
            var queryableCollection = await collection.AsQueryable().ToListAsync();
            foreach (var rank in queryableCollection)
            {
                rankList.Add(rank);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while listing data from collection {collectionName}: {ex.Message}");
        }
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
        var collection = database.GetCollection<GetRankResponse>("rank_test");



        List<string> rank_urls = new List<string>();
        foreach(var player in playerNames)
        {
            rank_urls.Add($"https://api.henrikdev.xyz/valorant/v2/mmr/na/{player}");
        }

        List<string> mmr_urls = new List<string>();
        foreach(var player in playerNames)
        {
            mmr_urls.Add($"https://api.henrikdev.xyz/valorant/v1/mmr-history/na/{player}");
        }

        var updatedRanks = await GetPlayerRanksHTTPAsync(mmr_urls, rank_urls);
        foreach (GetRankResponse player in updatedRanks)
        {
            //this filter should be puuid in the future
            var filter = Builders<GetRankResponse>.Filter.Eq(r => r.Data.Name, player.Data.Name);
            var update = Builders<GetRankResponse>.Update.Set(r => r.Data, player.Data);
            var result = await collection.UpdateOneAsync(filter, update);
        }
        await OnInitializedAsync();
    }

    public async Task<List<GetRankResponse>> GetPlayerRanksHTTPAsync(List<string> mmr_urls, List<string> rank_urls)
    {
        Console.WriteLine("getting ranks...");
        
        var ranks = new List<GetRankResponse>();

        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Authorization", Program.henrik_API_Key);
        
        var mmr_requests = mmr_urls.Select(url => client.GetStringAsync(url)).ToList();
        await Task.WhenAll(mmr_requests);

        var rank_requests = rank_urls.Select(url => client.GetStringAsync(url)).ToList();
        await Task.WhenAll(rank_requests);

        var mmr_responses = mmr_requests.Select(task => MMRHistoryResponse.FromJson(task.Result)).ToList();
        var rank_responses = rank_requests.Select(task => GetRankResponse.FromJson(task.Result)).ToList();

        var count = 0;
        foreach (var rank in rank_responses)
        {
            if (rank is not null)
            {
                // Console.WriteLine(rank.Data.CurrentData.Currenttierpatched);
                rank.Data.MMR = mmr_responses[count];
                Console.WriteLine($"{rank.Data.Name} \t {rank.Data.CurrentData.Currenttierpatched}");
                

                if (rank.Data.BySeason.E9A1.Error == "No data Available" || rank.Data.BySeason.E9A1.FinalRankPatched == "Unrated" || rank.Data.BySeason.E9A1.NumberOfGames == 0)
                {
                    rank.Data.CurrentData.Elo = 0;
                    rank.Data.CurrentData.RankingInTier = 0;
                    rank.Data.CurrentData.Currenttierpatched = "Unrated";
                    rank.Data.CurrentData.Images.Small = new System.Uri("https://media.valorant-api.com/competitivetiers/564d8e28-c226-3180-6285-e48a390db8b1/0/smallicon.png");
                }
                ranks.Add(rank);
            }
            else{
                Console.WriteLine("ERROR: rank is null");
            }
            count += 1;
        }

        Console.WriteLine("got all ranks");
        

        return ranks;

        // static async Task<GetRankResponse?> ProcessRepositoriesAsync(HttpClient client, string player)
        // {
        //     GetRankResponse? rank = GetRankResponse.FromJson(await client.GetStringAsync($"https://api.henrikdev.xyz/valorant/v2/mmr/na/{player}"));
        //     if (rank == null)
        //     {
        //         Console.WriteLine("rank is null");
        //         return null;
        //     }
            
        //     var mmr = MMRHistoryResponse.FromJson(await client.GetStringAsync($"https://api.henrikdev.xyz/valorant/v1/mmr-history/na/{player}"));

        //     if (mmr == null)
        //     {
        //         Console.WriteLine("mmr is null");
        //         return null;
        //     }

        //     rank.Data.MMR = mmr;

        //     return rank;

        // }



        // foreach (var player in playerNames)
        // playerNames.ForEach(async (player) => 
        // {
        //     // Console.Write($"{player}'s rank ...\t ");
        //     using HttpClient client = new();

        //     var rank = await ProcessRepositoriesAsync(client, player);

        // });
    }
}