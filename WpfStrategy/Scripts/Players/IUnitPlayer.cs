using MongoDB.Bson.Serialization.Attributes;
namespace WpfStrategy.Scripts
{
    [BsonKnownTypes(typeof(Warrior), typeof(Wizard), typeof(Rogue))]
    public abstract class IUnitPlayer
    {
        public IUnitPlayer(double str, double dex, double intel, double vit)
        {
            Strength = str;
            Dexterity = dex;
            Inteligence = intel;
            Vitality = vit;
        }
        protected abstract double HealthOwn();
        protected abstract double ManaOwn();
        protected abstract double ArmorOwn();
        protected abstract double DamageOwn();
        protected abstract double MagicDamageOwn();
        protected abstract double MagicDefenceOwn();
        protected abstract double CritShanceOwn();
        protected abstract double CritDamageOwn();
        
        public double Strength { get; set; }
        public double Dexterity { get; set; }
        public double Inteligence { get; set; }
        public double Vitality { get; set; }

        public int MaxStrength { get; set; }
        public int MaxDexterity { get; set; }
        public int MaxInteligence { get; set; }
        public int MaxVitality { get; set; }

        public double Health { get { return HealthOwn(); } set { } }    
        public double Mana { get { return ManaOwn();  } set { } }
        public double Damage { get { return DamageOwn();  } set { } }
        public double Armor { get { return ArmorOwn();  } set { } }
        public double MagicDamage { get { return MagicDamageOwn(); } set { } }
        public double MagicDefense { get { return MagicDefenceOwn();  } set { } }
        public double CritShance { get { return CritShanceOwn(); } set { } }
        public double CritDamage { get { return CritDamageOwn(); } set { } }
        public abstract void LvlUp();

        public abstract void DisLvlUp();
     
    }
}
