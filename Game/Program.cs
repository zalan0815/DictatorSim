namespace Game
{
    internal class Program
    {
        static Player player;
        static int printLenght;
        static void Main(string[] args)
        {
            //FightSystem f = new FightSystem(new Player(500, 10, 1, 0), new Enemy(200, 10), out bool won);
            Locations.Generate();
            player = new Player(10, 10, 1, 180);
            printLenght = Console.WindowWidth - 30;
            Shop shop = new Shop(new Sword("Lézerkard", 21, 60, StatType.Damage), new Armor("Netherite páncél", 42, 99, StatType.Health), new Sword("Nashor foga", 2, 123, StatType.SliderSpeed), new OtherItem("Garfield hűtőmágnes", 4, -2, StatType.Key));
            shop.ShopMenu(ref player);
        }
        static void SlowPrint(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Console.CursorLeft == printLenght)
                {
                    Console.Write(' ');
                    while (text[i] != ' ')
                    {
                        i--;
                        Console.CursorLeft -= 2;
                        Console.Write(' ');
                    }
                    Console.WriteLine(text[i]);
                    Thread.Sleep(25);
                }
                else
                {
                    Console.Write(text[i]);
                    Thread.Sleep(25);
                }
            }
            Console.WriteLine();
        }
        static int getPlayerStatLength()
        {
            int longest = "életerőd".Length;
            foreach (Item item in player.Items)
            {
                if (longest < item.WriteItemStat(true, false))
                {
                    longest = item.WriteItemStat(true, false);
                }
            }
            foreach (Item item in player.Inventory)
            {
                if (longest < item.WriteItemStat(true, false))
                {
                    longest = item.WriteItemStat(true, false);
                }
            }
            if(longest < player.Money.ToString().Length)
            {
                longest = player.Money.ToString().Length;
            }
            longest = longest >= $"{player.Health} / {player.MaxHealth}".Length ? longest : $"{player.Health} / {player.MaxHealth}".Length;
            return longest;
        }
        public static int PrintPlayerStat(bool yellowHealth = false)
        {
            int longest = getPlayerStatLength();

            Console.CursorLeft = Console.WindowWidth - longest - 1;
            Console.CursorTop = 0;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Életerőd");
            Console.CursorLeft = Console.WindowWidth - longest - 1;
            Console.CursorTop += 1;
            if (yellowHealth) { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.Write($"{player.Health} ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"/ {player.MaxHealth}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorLeft = Console.WindowWidth - longest - 1;
            Console.CursorTop += 1;
            Console.Write("Pénzed");
            Console.CursorLeft = Console.WindowWidth - longest - 1;
            Console.CursorTop += 1;
            Console.Write(player.Money);

            Console.CursorTop += 1;

            foreach (Item item in player.Items)
            {
                Console.CursorLeft = Console.WindowWidth - longest - 1;
                Console.CursorTop += 1;
                item.WriteItemStat(true);
            }
            foreach (Item item in player.Inventory)
            {
                Console.CursorLeft = Console.WindowWidth - longest - 1;
                Console.CursorTop += 1;
                item.WriteItemStat(true);
            }

            printLenght = Console.WindowWidth - longest - 2;
            return longest;
        }
    }
}