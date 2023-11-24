using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    partial class Locations
    {
        public delegate int LocationMethod();

        public static LocationData[] helyek;
        public struct LocationData
        {
            private static int globID = 0;
            private int id;
            public int ID { get { return id; } }
            public string Name { get; set; }
            public LocationMethod myMethod;
            public int Run()
            {
                return myMethod.Invoke();
            }

            public LocationData(string name, LocationMethod method)
            {
                id = globID++;
                this.Name = name;
                this.myMethod = method;
            }
        }
        public static void Generate()
        {
            helyek = new LocationData[31] {
                new LocationData("Ágy",basic),
                new LocationData("Ház",basic),
                new LocationData("Markotabödöge",basic),
                new LocationData("Bánya", basic),
                new LocationData("Föld",basic),
                new LocationData("Kovács", basic),
                new LocationData("Kerekerdő", basic),
                new LocationData("Tisztás",basic),
                new LocationData("Bokor",basic),
                new LocationData("Hókuszpók háza",basic),
                new LocationData("Gombafalu",basic),
                new LocationData("Égig érő paszuly",basic),
                new LocationData("Boszorkányház",basic),
                new LocationData("Hegység",basic),
                new LocationData("Óriások barlangja",basic),
                new LocationData("Kutyafejű tatárok országa",basic),
                new LocationData("Kutyafejű tatárok erdeje",basic),
                new LocationData("Kutyafejű tatárok városa",basic),
                new LocationData("Remete",basic),
                new LocationData("Pokol", basic),
                new LocationData("Tündérország", basic),
                new LocationData("Tündérország kék ház", basic),
                new LocationData("Tündérország piros ház", basic),
                new LocationData("Tündérország zöld ház",basic),
                new LocationData("Tündérkirályásg", basic),
                new LocationData("Város",basic),
                new LocationData("Kocsma", basic),
                new LocationData("Kereskedő",basic),
                new LocationData("Kacsalábon forgó palota",basic),
                new LocationData("Sárkányfészek", basic),
                new LocationData("Kacsalábon forgó kacsalábon forgó palota",basic),

            };

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
        public static int basic()
        {
            return 0;
        }
    }
}
