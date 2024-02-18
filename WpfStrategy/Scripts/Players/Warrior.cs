using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Windows;


namespace WpfStrategy.Scripts
{
     public class Warrior : IUnitPlayer
    {
        public override void LvlUp()
        {
            if (MaxStrength > Strength)
            {
                Strength += 2.24;
                Dexterity += 0.66;
                Inteligence += 0.41;
                Vitality += 0.77;
            }
            else
                MessageBox.Show("Макисмальный уровень уже достигнут");
        }
        public override void DisLvlUp()
        {
            Strength -= 2.24;
            Dexterity -= 0.66;
            Inteligence -= 0.41;
            Vitality -= 0.77;
        }
        protected override double HealthOwn()
        {
            return Vitality * 2;
        }
        protected override double ManaOwn()
        {
            return Inteligence;
        }
        protected override double DamageOwn()
        {
            return Strength;
        }
        protected override double ArmorOwn()
        {
            return Dexterity;
        }
        protected override double MagicDamageOwn()
        {
            return Inteligence * 0.2;
        }
        protected override double MagicDefenceOwn()
        {
            return  0.5 * Inteligence;
        }

        protected override double CritShanceOwn()
        {
            return Dexterity * 0.2;
        }

        protected override double CritDamageOwn()
        {
            return Dexterity * 0.1;
        }

        public Warrior() :base (30,15,10,25.40)
        {
            MaxStrength = 250;
            MaxDexterity = 80;
            MaxInteligence = 50;
            MaxVitality = 100;
        }
    }
}
