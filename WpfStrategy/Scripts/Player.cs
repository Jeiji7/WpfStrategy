using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategy.Scripts
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Lvl { get; set; }
        public Player(string name, string clas, int lvl) 
        {
            Name = name;
            Class = clas;
            Lvl = lvl;
        }
        public ObjectId _id;
    }
}
