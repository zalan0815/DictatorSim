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
            player = new Player(10, 10, 1, 100);
            printLenght = Console.WindowWidth - 30;
            Shop shop = new Shop(new List<Item>() { new Sword("Lézerkard", 10, 60, StatType.Damage), new Armor("Netherite páncél", 10, 99, StatType.Health), new Sword("Nashor foga", 2, 123, StatType.SliderSpeed), new OtherItem("Garfield hűtőmágnes", 4, -2, StatType.Key) });
            shop.ShopMenu(ref player);
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
                Console.WriteLine();
            }
        }
    }
}