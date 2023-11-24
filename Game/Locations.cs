using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Locations
    {
        public static LocationData[] helyek;
        public struct LocationData
        {
            private static int globID = 0;
            private int id;
            public int ID { get { return id; } }
            public string Name { get; set; }

            public LocationData(string name)
            {
                id = globID++;
                this.Name = name;
            }
        }
        public static void Asd()
        {
            helyek = new LocationData[31] {
                new LocationData("Ágy"),
                new LocationData("Ház"),
                new LocationData("Markotabödöge"),
                new LocationData("Bánya"),
                new LocationData("Föld"),
                new LocationData("Kovács"),
                new LocationData("Kerekerdő"),
                new LocationData("Tisztás"),
                new LocationData("Bokor"),
                new LocationData("Hókuszpók háza"),
                new LocationData("Gombafalu"),
                new LocationData("Égig érő paszuly"),
                new LocationData("Boszorkányház"),
                new LocationData("Hegység"),
                new LocationData("Óriások barlangja"),
                new LocationData("Kutyafejű tatárok országa"),
                new LocationData("Kutyafejű tatárok erdeje"),
                new LocationData("Kutyafejű tatárok városa"),
                new LocationData("Remete"),
                new LocationData("Pokol"),
                new LocationData("Tündérország"),
                new LocationData("Tündérország kék ház"),
                new LocationData("Tündérország piros ház"),
                new LocationData("Tündérország zöld ház"),
                new LocationData("Tündérkirályásg"),
                new LocationData("Város"),
                new LocationData("Kocsma"),
                new LocationData("Kereskedő"),
                new LocationData("Kacsalábon forgó palota"),
                new LocationData("Sárkányfészek"),
                new LocationData("Kacsalábon forgó kacsalábon forgó palota"),

            };
            Tovabb(helyek[1], helyek[2]);
        }

        public static int Tovabb(params LocationData[] helyek)
        {
            Console.WriteLine("Tovább mész:");
            for (int i = 1; i < helyek.Length + 1; i++)
            {
                Console.WriteLine($"{i}. - {helyek[i - 1].Name}");
            }
            int choice;
            bool error = false;
            while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out choice) || (choice < 1 || choice > helyek.Length))
            {
                if (!error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Olyan helyet választottál, ami még eme mesés helyen sem létezik!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Próbáld újra!");
                    error = true;
                }
            }
            Console.Write("\nÉs Palkó ");
            Thread.Sleep(500);
            Console.Write("ment ");
            Thread.Sleep(500);
            Console.Write("ment ");
            Thread.Sleep(500);
            Console.Write($"mendegélt tovább {helyek[choice - 1].Name} felé.\n");
            return helyek[choice - 1].ID;
        }
    }
}
