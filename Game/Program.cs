using Game.Minigames;

namespace Game
{
    partial class Program
    {
        public static Player player = new Player(10, 10, 1, 100);
        public static int printLenght = Console.WindowWidth - 30;

        static void Main(string[] args)
        {
            new TyperGame(player, "Jelenleg egy sor van tamogatva ekezetek nelkul").Run();
            Locations.Generate();
            int location = 6;

            do
            {
                location = Locations.helyek[location].Run();
            }
            while (Locations.helyek.Length > location && location > 0);
            Console.Write("Program end");

            //MiningGame mine = new MiningGame();
            //mine.Mining('a', 'x');
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
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            return longest;
        }
    }
}