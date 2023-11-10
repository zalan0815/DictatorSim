using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        #region VARIABLES
        private int health;
        private int money;

        private int defaultHealth;
        private int defaultStrength;
        private int defaultSliderSpeed;

        public Sword sword;
        public Armor armor;
        #endregion

        #region FIELDS
        public Item[] Items
        {
            get 
            { 
                return new Item[2] {this.sword, this.armor};
            }
        }

        public int Health
        {
            get { return health; }
            set 
            {
                if (health <= value) {
                    health = value;
                }
                else
                {
                    health = MaxHealth;
                }
                
            }
        }
        public int Money
        {
            get { return money; }
            set { money = value; }
        }


        public int MaxHealth
        {
            get
            { 
                return defaultHealth + calculateStat(StatType.Health);
            }
        }

        public int SliderSpeed
        {
            get
            {
                return defaultSliderSpeed + calculateStat(StatType.SliderSpeed);
            }
        }

        public int Damage
        {
            get
            {
                return defaultStrength + calculateStat(StatType.Damage);
            }
        }
        #endregion

        public Player(int health, int strength, int sliderSpeed, int money)
        {
            this.defaultHealth = health;
            this.defaultStrength = strength;
            this.defaultSliderSpeed = sliderSpeed;

            this.health = health;
            this.money = money;
        }

        private int calculateStat(StatType type)
        {
            int stat = 0;
            foreach (Item item in this.Items)
            {   
                if (item.Type == type)
                {
                    stat += item.Stat;
                }
            }
            return stat;
        }
    }
}
