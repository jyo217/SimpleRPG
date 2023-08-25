using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    internal class StrengthPotion : IItem
    {
        private string name = "STR_Potion";
        private int effect;
        public StrengthPotion(int effect) { this.effect = effect; }

        public string Name { get { return name; } set { name = value; } }
        public void Use(Warrior warrior) { warrior.Atk += effect; }
    }
}
