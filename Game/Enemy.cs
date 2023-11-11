using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy : Character
    {
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public Enemy(int health, int strength, int speed=2500, string name = "Enemy")
        {
            this.MaxHealth = health;
            this.Health = health;
            this.Damage = strength;
            this.speed = speed;

            this.Name = name;
        }
    }
}
