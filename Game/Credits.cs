using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static Game.Program;

namespace Game
{
    internal class Credits
    {
        static int h = Console.WindowWidth;
        public static int CreditScreen(int speed)
        {
            Console.Clear();
            Console.CursorTop = h;
            Console.WriteLine(new string(' ', (Console.WindowWidth - sorok[0].Length) / 2) + sorok[0]);
            Thread.Sleep(speed);
            for (int i = 1; i < sorok.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine(new string(' ', (Console.WindowWidth - sorok[i].Length) / 2) + sorok[i]);
                Thread.Sleep(speed);
            }
            for (int i = 0; i < sorok.Length - 8; i++)
            {
                Console.WriteLine();
                Thread.Sleep(speed);
            }
            return -1;
        }
    }
}
