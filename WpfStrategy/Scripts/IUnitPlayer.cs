using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategy.Scripts
{
    internal interface IUnitPlayer
    {
        public int Strength { get; set; }
        int Dexterity { get; set; }
        int Inteligence { get; set; }
        int Vitality { get; set; }
        int MaxStrength { get; set; }
        int MaxDexterity { get; set; }
        int MaxInteligence { get; set; }
        int MaxVitality { get; set; }
        int Health { get; set; }    
        int Mana {  get; set; }
        int Damage { get; set; }
        int Armor { get; set; }
        int MagicDamage { get; set; }
        int MagicDefense { get; set; }
        void LvlUp();
        void DisLvlUp();
    }
}
