using Game.Minigames;

namespace Game
{
    partial class Program
    {
        public static Player player = new Player(10, 20, 1, 1000);

        public static int printLenght = Console.WindowWidth - 30;

        static void Main(string[] args)
        {
            Locations.Generate();
            int location = 25;
            do
            {
                location = Locations.helyek[location].Run();
            }
            while (Locations.helyek.Length > location && location >= 0);
            Console.ForegroundColor = ConsoleColor.Black; 
            Console.ReadKey(true);
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
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            string[] namesToWrite = { "Életerőd", "Pénzed", "Varázsitaljaid" };
            string[] statsToWrite = { $"{player.Health} / {player.MaxHealth}", player.Money.ToString(), player.HealPotions.ToString() };
            ConsoleColor[] colorsToWrite = { ConsoleColor.Green, ConsoleColor.DarkYellow, ConsoleColor.DarkRed };

            Console.CursorTop = 0;
            for (int i = 0; i < statsToWrite.Length; i++)
            {
                Console.CursorLeft = Console.WindowWidth - longest - 1;
                Console.ForegroundColor = colorsToWrite[i];
                if(yellowHealth && i == 0) { Console.ForegroundColor = ConsoleColor.Yellow; }
                Console.Write(namesToWrite[i]);
                Console.WriteLine(new string(' ', Console.WindowWidth - Console.CursorLeft));
                Console.CursorLeft = Console.WindowWidth - longest - 1;
                Console.Write(statsToWrite[i]);
                Console.WriteLine(new string(' ', Console.WindowWidth - Console.CursorLeft));
            }

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
            Console.CursorLeft = x;
            Console.CursorTop = y;
            return longest;
        }
    }
}