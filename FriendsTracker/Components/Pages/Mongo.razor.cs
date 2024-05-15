using MongoDB.Bson;
using MongoDB.Driver;
using FriendsTracker.Components.Infrastructure;
using MongoDB.Bson.Serialization;

namespace FriendsTracker.Components.Pages;


public partial class Mongo
{
    public IMongoDatabase GetDatabase(string databaseName, string connectionString)
    {
        var client = new MongoClient(connectionString);
        return client.GetDatabase(databaseName);
    }

    public void ListAllData<T>(string databaseName, string collectionName, string connectionString)
    {

        var database = GetDatabase(databaseName, connectionString);
        var collection = database.GetCollection<BsonDocument>(collectionName);
        var filter = Builders<BsonDocument>.Filter.Empty; // Empty filter to match all documents
        try
        {
            var queryableCollection = collection.AsQueryable().First();

            Console.WriteLine("DOCUMENT count:" + collection.CountDocuments(filter));
            var rank = BsonSerializer.Deserialize<GetRankResponse>(queryableCollection);
            Console.WriteLine("RANK OBJECT:" + rank.ToJson());
            Console.WriteLine("RANK OBJECT:" + rank.Data.Name + rank.Data.CurrentData.Currenttierpatched);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while listing data from collection {collectionName}: {ex.Message}");
        }
    }

    public string realResult = "NO DATA";

    public void ButtonFunction()
    {
        var connectionString = $"mongodb+srv://brewt:{Program.mongoKey}@cluster0.xpbkg6w.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        ListAllData<string>("player_data_db", "rank", connectionString);

    }
}


