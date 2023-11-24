using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Shop
    {
        public static string[] randomShopTexts = { "A pultnál kérdezősködve az alábbiakat ajánlják neked: ",  "A pulthoz érve rögvest észreveszed a kiemelt tárgyakat", "A bolt üres, így hamar sorra is kerülsz.", "Elvileg ez a legjobb bolt a közelben..."};
        public static string[] randomShopConversations = { "\"Ezeket csak neked tartogattam!\"", "\"Szép napunk van nemde?\"", "\"Ha én ennyi idős lehetnék, mint te most...\"", "\"A mai első vevőm!!!\""};

        private List<Item> items;
        public List<Item> Items { get { return items; } set { items = value; } }

        public Shop(List<Item> items)
        {
            this.items = items;
        }

        public string randomText(params string[] text)
        {
            return text[new Random().Next(0,text.Length)];
        }

        public void purchaseItem(ref Player player, int itemId)
        {
            Item item = items[itemId];
            Type itemType = item.GetType();
            if(itemType == typeof(Sword))
            {
                player.sword = item as Sword;
            }
            else if(itemType == typeof(Armor))
            {
                player.armor = item as Armor;
            }
            else
            {
                player.Inventory.Add(item as OtherItem);
            }
            player.Money -= item.Price;
            items.RemoveAt(itemId);
        }

        public void printShop(ref Player player, string txt1, string txt2)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine($"{txt1}\n");
            Console.WriteLine($"{txt2}\n");
            Console.WriteLine($"{player.Money}");

            for (int i = 0; i < items.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"{i + 1}, ");
                items[i].WriteItemStat();
                Console.Write(" - ");
                if (player.Money < items[i].Price)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine($"{items[i].Price} krajcár");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n0, elmenni a pulttól");
        }

        public void ShopMenu(ref Player player)
        {
            string shopText = randomText(randomShopTexts);
            string conversation = randomText(randomShopConversations);

            int input;
            do
            {
                do
                {
                    printShop(ref player, shopText, conversation);
                }
                while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input) || input < 0 || input > items.Count);

                if (input != 0 && player.Money >= items[input - 1].Price)
                {
                    purchaseItem(ref player, input - 1);
                }
            }
            while (input != 0);
        }
    }
}
