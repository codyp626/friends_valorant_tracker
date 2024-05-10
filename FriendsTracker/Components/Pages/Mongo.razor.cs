// using MongoDB.Driver;
// using MongoDB.Bson;
// using Microsoft.VisualBasic;

// namespace FriendsTracker.Components.Pages;

// public partial class Mongo
// {
//     private string connectionString = "mongodb+srv://brewt:<password>@cluster0.xpbkg6w.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
//     // public List<object> ResultList { get; private set; }
//     public string ResultList { get; private set; } = "null";
//     // public Mongo(string connectionString)
//     // {
//     //     _connectionString = connectionString;
//     // }

//     public IMongoDatabase GetDatabase()
//     {
//         var databaseName = "player_data_db";
//         var client = new MongoClient(connectionString);
//         return client.GetDatabase(databaseName);
//     }

//     public void ListAllData<T>()
//     {
//         var collectionName = "rank";
//         var database = GetDatabase();
//         var collection = database.GetCollection<T>(collectionName);
//         var filter = Builders<T>.Filter.Empty; // Empty filter to match all documents
//         try
//         {
//             var weird_list = collection.Find(filter);
//             ResultList = weird_list.ToString();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error while listing data from collection {collectionName}: {ex.Message}");
//         }
//     }

// }

using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MongoDB.Bson.IO;
using FriendsTracker.Components.Infrastructure;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace FriendsTracker.Components.Pages;


public partial class Mongo
{
    private readonly string _connectionString;
    public List<string> ResultList { get; private set; }

    // public Mongo()
    // {
    //     _connectionString = "your_default_connection_string_here";
    // }

    public IMongoDatabase GetDatabase(string databaseName, string connectionString)
    {
        var client = new MongoClient(connectionString);
        return client.GetDatabase(databaseName);
    }

    public void ListAllData<T>(string databaseName, string collectionName, string connectionString)
    {
        BsonClassMap.RegisterClassMap<GetRankResponse>(classMap =>
        {
            classMap.AutoMap();
        //     classMap.MapMember(p => p.Id);
        //     classMap.MapMember(p => p.Status);
        //     classMap.MapMember(p => p.Data);
        });

        var database = GetDatabase(databaseName, connectionString);
        var collection = database.GetCollection<GetRankResponse>(collectionName);
        // var filter = Builders<T>.Filter.Empty; // Empty filter to match all documents
        try
        {
            // ResultList = collection.Find(filter).ToEnumerable().Select(d => d.ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson })).ToList();
            // var string_results = collection.Find(filter).ToEnumerable();
            var queryableCollection = collection.AsQueryable().First();

            // Console.WriteLine("DOCUMENT count:" + queryableCollection.Count());
            Console.WriteLine("DOCUMENT count:" + queryableCollection.ToJson());

            // Console.WriteLine(queryableCollection.ToJson());
            // foreach (var doc in queryableCollection)
            // {
            //     Console.WriteLine(doc.ToJson());
            // }

            // var documents = collection.Find(filter);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while listing data from collection {collectionName}: {ex.Message}");
        }
    }

    public string realResult = "NO DATA";

    public void ButtonFunction()
    {
        var connectionString = "mongodb+srv://brewt:<password>@cluster0.xpbkg6w.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        ListAllData<string>("player_data_db", "rank", connectionString);
        // foreach (var doc in ResultList)
        // {
        //     // realResult+= doc;
        //     // Process each document here
        // }

    }
}


