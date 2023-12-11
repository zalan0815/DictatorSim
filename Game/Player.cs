﻿using System;
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

        private Sword sword = new Sword("Kés",10);
        private Armor armor = new Armor("Szakadt ruha",10);

        private int healPotions;
        #endregion

        #region FIELDS
        public List<Item> Items
        {
            get 
            { 
                return new List<Item>() { this.sword, this.armor};
            }
        }

        public Sword Sword
        {
            get { return sword; }
            set
            {
                sword = value;
                addHealthByItem(value);
            }
        }
        public Armor Armor
        {
            get { return armor; }
            set
            {
                armor = value;
                addHealthByItem(value);
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

        public int HealPotions { get { return healPotions; } set { healPotions = value; } }

        
        #endregion

        public Player(int health, int strength, int sliderSpeed, int money, string name = "Palko")
        {
            this.defaultHealth = health;
            this.defaultStrength = strength;
            this.defaultSliderSpeed = sliderSpeed;

            this.Health = MaxHealth;
            this.Money = money;

            this.Name = name;
            this.HealPotions = 0;
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

        public void NewItem(OtherItem item)
        {
            inventory.Add(item);
            SlowPrintSystem.SlowPrintLine($"Új tárgyat kaptál: {item.Name}!");
        }

        public void Heal()
        {
            HealPotions--;
            Health = MaxHealth;
        }

        private void addHealthByItem(Item item)
        {
            if(item.Type == StatType.Health)
            {
                Health += item.Stat;
            }
        }
    }
}
