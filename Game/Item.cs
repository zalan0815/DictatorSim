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

        public int WriteItemStat(bool withItemsName = true, bool writeOut = true)
        {
            int lenght = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            if (withItemsName)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (writeOut)
                {
                    Console.Write($"{this.Name} (");
                }
                lenght += $"{this.Name} (".Length;
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
            if(writeOut)
            {
                Console.Write($"{this.Stat} {typeText}");
            }
            lenght += $"{this.Stat} {typeText}".Length;
            Console.ForegroundColor = ConsoleColor.White;
            if (withItemsName)
            {
                if(writeOut)
                {
                    Console.Write(")");
                }
                lenght += 1;
            }

            return lenght;
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
