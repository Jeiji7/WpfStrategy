using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace WpfStrategy.Scripts
{
    public class CRUD
    {
        //private static IMongoCollection<Player> collection;

        //public static IMongoCollection<Player> GetCollection()
        //{
        //    return collection;
        //}

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
        public static void UpdatePlayerState(Player player)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("StrategyGame");
            var collection = database.GetCollection<Player>("AllHeros");
            var filter = Builders<Player>.Filter.Eq(p => p._id, player._id);
            var update = Builders<Player>.Update
                .Set("classification.Strength", player.classification.Strength)
                .Set("classification.Dexterity", player.classification.Dexterity)
                .Set("classification.Inteligence", player.classification.Inteligence)
                .Set("classification.Vitality", player.classification.Vitality)
                .Set("classification.Health", player.classification.Health)
                .Set("classification.Mana", player.classification.Mana)
                .Set("classification.Damage", player.classification.Damage)
                .Set("classification.Armor", player.classification.Armor)
                .Set("classification.MagicDamage", player.classification.MagicDamage)
                .Set("classification.MagicDefense", player.classification.MagicDefense)
                .Set("classification.CritShance", player.classification.CritShance)
                .Set("classification.CritDamage", player.classification.CritDamage)
                .Set(p => p.Lvl, player.Lvl)
                .Set(p => p.LvlPoints, player.LvlPoints)
                .Set(p => p.CountyPoint, player.CountyPoint)
                .Set(p => p.MaxCountyPoint, player.MaxCountyPoint)
                .Set("weapons.Number", player.weapons.Number)
                .Set("weapons.Type", player.weapons.Type)
                .Set("weapons.Name", player.weapons.Name)
                .Set("weapons.OneState", player.weapons.OneState)
                .Set("weapons.TwoState", player.weapons.TwoState)
                .Set("weapons.TreeState", player.weapons.TreeState)
                .Set("weapons.FourState", player.weapons.FourState)
                .Set("weapons.FiveState", player.weapons.FiveState)
                .Set("weapons.SixState", player.weapons.SixState)
                .Set("weapons.SevenState", player.weapons.SevenState);
            collection.FindOneAndUpdate(filter, update);
           
        }
    }
}
