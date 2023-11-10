namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            FightSystem f = new FightSystem(new Player(10, 10, 10, 10), new Enemy(500, 10), out bool yes);
        }
    }
}