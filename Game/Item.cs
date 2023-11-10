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

        public void WriteItemStat(bool withItemsName = true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            if (withItemsName)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{this.Name} (");
            }
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleColor color;
            string typeText;
            switch (type)
            {
                case StatType.Health:
                    color = ConsoleColor.Green;
                    typeText = "hp";
                    break;
                case StatType.Damage:
                    color = ConsoleColor.DarkRed;
                    typeText = "dmg";
                    break;
                case StatType.SliderSpeed:
                    color = ConsoleColor.Yellow;
                    typeText = "prec";
                    break;
                default:
                    color = ConsoleColor.Magenta;
                    typeText = "";
                    break;
            }
            Console.ForegroundColor = color;
            Console.Write($"{this.Stat} {typeText}");
            Console.ForegroundColor = ConsoleColor.White;
            if (withItemsName) 
                Console.Write(")");
        }
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
