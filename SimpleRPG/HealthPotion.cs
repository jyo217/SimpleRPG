using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    internal class HealthPotion
    {
        private string name = "HEALTH_Potion";
        private int effect;
        public HealthPotion(int effect) { this.effect = effect; }

        public string Name { get { return name; } set { name = value; } }
        public void Use(Warrior warrior) { warrior.Health += effect; }
    }
}
