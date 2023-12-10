using Game.Minigames;

namespace Game
{
    partial class Program
    {
        public static Player player = new Player(10, 10, 1, 1000);

        #region Enemys
        public static Enemy csoves = new Enemy(30, 5, name: "csöves");
        public static Enemy balfej = new Enemy(100, 50, name: "Bal fej");
        public static Enemy kozepsofej = new Enemy(100, 50, name: "Középső fej");
        public static Enemy jobbfej = new Enemy(100, 50, name: "Jobb fej");
        public static Enemy asd = new Enemy(0, 0, name: "asd");
        //public static Enemy asd = new Enemy(0, 0, name: "asd");
        //public static Enemy asd = new Enemy(0, 0, name: "asd");
        //public static Enemy asd = new Enemy(0, 0, name: "asd");
        #endregion

        public static int printLenght = Console.WindowWidth - 30;

        static void Main(string[] args)
        {
            Locations.Generate();
            int location = 28;

            do
            {
                location = Locations.helyek[location].Run();
            }
            while (Locations.helyek.Length > location && location > 0);
            Console.Write("Program end");
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
                Console.WriteLine(namesToWrite[i]);
                Console.CursorLeft = Console.WindowWidth - longest - 1;
                Console.WriteLine(statsToWrite[i]);
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