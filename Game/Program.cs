namespace Game
{
    internal class Program
    {
        static Player player;
        static int printLenght; 
        static void Main(string[] args)
        {
            //FightSystem f = new FightSystem(new Player(500, 10, 1, 0), new Enemy(200, 10), out bool won);
            player = new Player(10, 10, 1, 0);
            printLenght = Console.WindowWidth - 30;
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
    }
}