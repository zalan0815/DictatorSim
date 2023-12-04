using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Character
    {
        private string name;
        private int maxHealth;
        private int health;
        private int damage;

        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
        virtual public int MaxHealth 
        { 
            get {  return maxHealth; } 
            set {  maxHealth = value; } 
        }
        virtual public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Health
        {
            get { return health; }
            set
            {
                if (value > MaxHealth)
                {
                    health = MaxHealth;
                }
                else if(value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }

            }
        }



    }
}
