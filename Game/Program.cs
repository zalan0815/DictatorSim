using System.Security.Principal;

namespace Game
{
    partial class Program
    {
        public static Player player = new Player(10, 10, 1, 180);
        public static int printLenght = Console.WindowWidth - 30;
        public static int printms = 100;


        public static Program program = new Program();
        static void Main(string[] args)
        {
            Locations.Generate();
            int location = 29;
            do
            {
                location = Locations.helyek[location].Run();
            }
            while (Locations.helyek.Length > location && location > 0);
            Console.Write("Program end");

            //SlowPrint("123456789abcdefghijklmnopqrestwvxyz");
        }
        
        public static void SlowPrint(string text)
        {
            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if(words[i].Length >= printLenght - Console.CursorLeft && !(words[i].Length >= printLenght))
                {
                    Console.WriteLine();
                }
                if(i < words.Length - 1)
                {
                    words[i] += " ";
                }
                
                SlowPrintWord(words[i]);
            }
            Console.WriteLine();
        }

        public static void SlowPrintWord(string word)
        {
            Stopwatch printStopWatch = new Stopwatch();
            int cursorPostion = Console.CursorLeft;
            for (int i = 0; i < word.Length; i++)
            {
                printStopWatch.Start();

                if (cursorPostion >= printLenght - 1)
                {
                    Console.Write("-");
                    Console.WriteLine();
                }
                Console.Write(word[i]);
                cursorPostion++;

                Thread.Sleep(printms > printStopWatch.ElapsedMilliseconds ? printms - (int)printStopWatch.ElapsedMilliseconds : printms);
            }
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