using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfStrategy.Scripts
{
    public class Rogue : IUnitPlayer
    {
        public override void LvlUp()
        {
            if (MaxDexterity > Dexterity)
            {
                Strength += 0.46;
                Dexterity += 2.24;
                Inteligence += 0.56;
                Vitality += 0.61;
            }
            else
                MessageBox.Show("Макисмальный уровень уже достигнут");
        }
        public override void DisLvlUp()
        {
            Strength -= 0.46;
            Dexterity -= 2.24;
            Inteligence -= 0.56;
            Vitality -= 0.61;
        }
        protected override double HealthOwn()
        {
            return Strength + 1.5 * Vitality;
        }
        protected override double ManaOwn()
        {
            return Inteligence * 1.2;
        }
        protected override double DamageOwn()
        {
            return Strength * 0.5 + 0.5 * Dexterity;
        }
        protected override double ArmorOwn()
        {
            return Dexterity * 1.5;
        }
        protected override double MagicDamageOwn()
        {
            return Inteligence * 0.2;
        }
        protected override double MagicDefenceOwn()
        {
            return 0.5 * Inteligence;
        }
        protected override double CritShanceOwn()
        {
            return Dexterity * 0.2;
        }

        protected override double CritDamageOwn()
        {
            return Dexterity * 0.1;
        }
        public Rogue(): base(20,30,15,20.40)
        {
            MaxStrength = 65;
            MaxDexterity = 250;
            MaxInteligence = 70;
            MaxVitality = 80;
        }
    }
}
