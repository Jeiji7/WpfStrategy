using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfStrategy.Scripts
{
    public class Wizard: IUnitPlayer
    {
        public override void LvlUp()
        {
            if (MaxInteligence > Inteligence)
            {
                Strength += 0.31;
                Dexterity += 0.61;
                Inteligence += 2.19;
                Vitality += 0.56;
            }
            else
                MessageBox.Show("Макисмальный уровень уже достигнут");
        }
        public override void DisLvlUp()
        {
            Strength -= 0.31;
            Dexterity -= 0.61;
            Inteligence -= 2.19;
            Vitality -= 0.56;
        }
        protected override double HealthOwn()
        {
            return Vitality * 1.5 + 0.2 * Strength;
        }
        protected override double ManaOwn()
        {
            return Inteligence * 1.5;
        }
        protected override double DamageOwn()
        {
            return Strength * 0.5;
        }
        protected override double ArmorOwn()
        {
            return Dexterity;
        }
        protected override double MagicDamageOwn()
        {
            return Inteligence;
        }
        protected override double MagicDefenceOwn()
        {
            return Inteligence;
        }
        protected override double CritShanceOwn()
        {
            return Dexterity * 0.2;
        }

        protected override double CritDamageOwn()
        {
            return Dexterity * 0.1;
        }
        public Wizard():base(15,20,35,15.40)
        {
            MaxStrength = 45;
            MaxDexterity = 80;
            MaxInteligence = 250;
            MaxVitality = 70;
        }
    }
}
