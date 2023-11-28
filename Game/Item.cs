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
        private bool sold;

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
        public bool Sold
        {
            get { return sold; }
            set { sold = value; }
        }
        #endregion

        public int WriteItemStat(bool withItemsName = true, bool writeOut = true, bool writeWithColor = true)
        {
            int lenght = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            if (withItemsName)
            {
                if (writeWithColor)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                if (writeOut)
                {
                    Console.Write($"{this.Name} (");
                }
                lenght += $"{this.Name} (".Length;
            }

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
                    typeText = "key";
                    break;
            }
            if (writeWithColor)
            {
                Console.ForegroundColor = color;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            
            if(writeOut)
            {
                Console.Write($"{this.Stat} {typeText}");
            }

            lenght += $"{this.Stat} {typeText}".Length;

            if (writeWithColor)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }

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
    class OtherItem : Item
    {
        public OtherItem(string name, int stat, int price = 0, StatType type = StatType.Health)
        {
            this.Name = name;
            this.Stat = stat;
            this.Price = price;
            this.Type = type;
        }
    }

}
