using MongoDB.Bson;
namespace WpfStrategy.Scripts
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Lvl { get; set; }
        public int LvlPoints {  get; set; }
        public int Imagers { get; set; }
        public IUnitPlayer classification;
        public WeaponsClass weapons;
        public int CountyPoint {  get; set; }
        public int MaxCountyPoint { get; set; }

        public Player(string name, string clas, int lvl, int lvlPoints, int countyPoint)
        {
            Name = name;
            Class = clas;
            Lvl = lvl;
            LvlPoints = lvlPoints;
            CountyPoint = countyPoint;
            MaxCountyPoint = CountyPoint;
        }
        public ObjectId _id;
    }
}
