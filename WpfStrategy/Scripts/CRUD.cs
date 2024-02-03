using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace WpfStrategy.Scripts
{
    public class CRUD
    {
        public static void CreateUser(Player player)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("StrategyGame");
            var collection = database.GetCollection<Player>("AllHeros");
            collection.InsertOne(player);
        }
        public static IEnumerable<Player> AllShowInfo()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("StrategyGame");
            var collection = database.GetCollection<Player>("AllHeros");
            var filter = Builders<Player>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            return result;
        }
    }
}
