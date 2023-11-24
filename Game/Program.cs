namespace Game
{
    internal class Program
    {
        static Player player;        
        static void Main(string[] args)
        {
            //FightSystem f = new FightSystem(new Player(500, 10, 1, 0), new Enemy(200, 10), out bool won);
            player = new Player(10, 10, 1, 0);
            int printLenght = Console.WindowWidth - 30;
            
        }
        static void SlowPrint(string text, int printLenght)
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
            Console.WriteLine('\n');
        }

        public static int hely_1()
        {
            SlowPrint("A történet a házadban veszi kezdetét, ahol egy szép napon reggel elhatározod, hogy elmész világot látni. ");
            return (2);
        }
    }
}