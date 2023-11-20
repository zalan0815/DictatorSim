using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static void Main(string[] args)
    {
        string[] helyek = { "hely1", "hely2", "hely3" };
        Console.WriteLine(Tovabb(helyek);
    }

    public static int Tovabb(string[] helyek)
    {
        Console.WriteLine("Tovább mész:");
        for (int i = 1; i < helyek.Length; i++)
        {
            Console.WriteLine($"{i}. - {helyek[i - 1]}");
        }
        int choice;
        while (!Int32.TryParse(Console.ReadKey(true).ToString(), out choice) && choice > 0 && choice <= helyek.Length)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Olyan helyet választottál, ami még eme mesés helyen sem létezik!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Próbáld újra!");
        }
        return choice;
    }
}
