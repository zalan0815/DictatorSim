using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy : Character
    {
        public Enemy(int health, int strength, string name = "Enemy")
        {
            this.MaxHealth = health;
            this.Health = health;
            this.Damage = strength;

            this.Name = name;
        }
    }
}
