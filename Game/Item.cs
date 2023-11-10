using System;
using System.Collections.Generic;

namespace Game
{
    enum StatType
    {
        Health,
        Damage,
        SliderSpeed,
        Key
    }
    abstract class Item
    {
        private string name;
        private StatType type;
        private int stat;
        private int price;

        #region FIELDS
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public StatType Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Stat
        {
            get { return stat; }
            set { stat = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion
    }
    class Sword : Item
    {
        public Sword(string name, int stat, int price = 0, StatType type = StatType.Damage)
        {
            this.Name = name;
            this.Stat = stat;
            this.Price = price;
            this.Type = type;
        }
        
    }
    class Armor : Item
    {
        public Armor(string name, int stat, int price = 0, StatType type = StatType.Health)
        {
            this.Name = name;
            this.Stat = stat;
            this.Price = price;
            this.Type = type;
        }

    }

}
