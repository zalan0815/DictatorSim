using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : Character
    {
        #region VARIABLES
        private int money;
        private List<OtherItem> inventory = new List<OtherItem>();

        private int defaultHealth;
        private int defaultStrength;
        private int defaultSliderSpeed;

        public Sword sword = new Sword("Kés",10);
        public Armor armor = new Armor("Szakadt ruha",10);
        #endregion

        #region FIELDS
        public List<Item> Items
        {
            get 
            { 
                return new List<Item>() { this.sword, this.armor};
            }
        }
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        public List<OtherItem> Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        public override int MaxHealth
        {
            get
            { 
                return defaultHealth + calculateStat(StatType.Health);
            }
        }
        public override int Damage
        {
            get
            {
                return defaultStrength + calculateStat(StatType.Damage);
            }
        }

        public int SliderSpeed
        {
            get
            {
                return defaultSliderSpeed + calculateStat(StatType.SliderSpeed);
            }
        }

        
        #endregion

        public Player(int health, int strength, int sliderSpeed, int money, string name = "Palko")
        {
            this.defaultHealth = health;
            this.defaultStrength = strength;
            this.defaultSliderSpeed = sliderSpeed;

            this.Health = health;
            this.Money = money;

            this.Name = name;
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
