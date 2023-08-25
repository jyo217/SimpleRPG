using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    internal class Monster
    {
        private string name;
        private int health;
        private int atk;
        private bool isDead;

        Monster(string name, int health, int atk, bool isDead)
        {
            this.name = name;
            this.health = health;
            this.atk = atk;
            this.isDead = isDead;
        }

        public string Name { get { return name; } set { name = value; } }
        public int Health { get { return health; } set { health = value; } }
        public int Atk { get { return atk; } set { atk = value; } }
        public bool IsDead { get { return isDead; } set { isDead = value; } }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                health = 0; isDead = true;
            }
        }
    }
}
