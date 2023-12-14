using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Game
{
    internal class Credits
    {
        static int h = Console.WindowWidth;

        static string[] sorok =
        {
            "A JÁTÉKOT KÉSZÍTETTE:",
            "Bende Huba",
            "Kovács Péter",
            "Tófalvi Zalán",
            "",
            "A JÁTÉKOT TESZTELTE:",
            "Bende Huba",
            "Kovács Péter",
            "Tófalvi Zalán",
            "Süke Benedek",
            "",
            "A KÉSZÍTÉST TERRORIZÁLTA:",
            "Csöngető Csongor",
            "Roncz Olivér",
            "Süke Benedek",
            "Pintér Bálint",
            "Reinhardt Benjámin",
            "",
            "KÜLÖN KÖSZÖNET:",
            "Az internetnek a segítségért",
            "Bognár Pál tanár úrnak a felkészítésért",
            "Süke Bendeknek a középre igazításért"
        };

        public static int CreditScreen(int speed = 150)
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
            for (int i = 0; i < sorok.Length + 10; i++)
            {
                Console.WriteLine();
                Thread.Sleep(speed);
            }
            return -1;
        }
    }
}
