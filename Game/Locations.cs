using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    partial class Locations
    {
        public delegate int LocationMethod(ref LocationData currentLocation);

        public static LocationData[] helyek;
        public struct LocationData
        {
            private static int globID = 0;
            private int id;
            private bool[] chosenOptions;
            private string name;
            public readonly int ID { get { return id; } }
            public bool[] ChosenOptions { get { return chosenOptions; } set { chosenOptions = value; } }
            public string Name { get { return name; } set { name = value; } }

            public LocationMethod myMethod;
            public int Run()
            {
                return myMethod.Invoke(ref this);
            }

            public int Valasztas(params string[] lehetosegek)
            {
                return Locations.Valasztas(ref this, lehetosegek);
            }

            public LocationData(string name, LocationMethod method)
            {
                this.id = globID++;
                this.name = name;
                this.chosenOptions = new bool[6]; //maximum 6 választási lehetőség
                this.myMethod = method;
            }
        }
        public static void Generate()
        {
            helyek = new LocationData[31] {
                new LocationData("Ágy",basic),
                new LocationData("Ház",hely_1),
                new LocationData("Markotabödöge",hely_2),
                new LocationData("Bánya", hely_3),
                new LocationData("Föld",hely_4),
                new LocationData("Kovács", hely_5),
                new LocationData("Kerekerdő", hely_6),
                new LocationData("Tisztás",hely_7),
                new LocationData("Bokor",hely_8),
                new LocationData("Hókuszpók háza",hely_9),
                new LocationData("Gombafalu",hely_10),
                new LocationData("Égig érő paszuly",hely_11),
                new LocationData("Boszorkányház",hely_12),
                new LocationData("Hegység",hely_13),
                new LocationData("Óriások barlangja",hely_14),
                new LocationData("Kutyafejű tatárok országa",hely_15),
                new LocationData("Kutyafejű tatárok erdeje",hely_16),
                new LocationData("Kutyafejű tatárok városa",hely_17),
                new LocationData("Remete",hely_18),
                new LocationData("Pokol", hely_19),
                new LocationData("Tündérország", hely_20),
                new LocationData("Tündérország kék ház", hely_21),
                new LocationData("Tündérország piros ház", hely_22),
                new LocationData("Tündérország zöld ház",hely_23),
                new LocationData("Tündérkirályásg", hely_24),
                new LocationData("Város",hely_25),
                new LocationData("Kocsma", hely_26),
                new LocationData("Kereskedő",hely_27),
                new LocationData("Kacsalábon forgó palota",hely_28),
                new LocationData("Sárkányfészek", hely_29),
                new LocationData("Kacsalábon forgó kacsalábon forgó palota",hely_30),

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
        public static int Valasztas(ref LocationData currentLocation, params string[] lehetosegek)
        {
            #region Biztosíték
            if (lehetosegek.Length > currentLocation.ChosenOptions.Length)
            {
                throw new Exception("túl sok választási lehetőség");
            }

            bool foundChoosable = false;
            for (int i = 0; i < lehetosegek.Length; i++)
            {
                if (!currentLocation.ChosenOptions[i])
                {
                    foundChoosable = true;
                    break;
                }
            }
            if (!foundChoosable)
            {
                return -1; //switch case default kezelje majd
            }
            #endregion

            Console.WriteLine("Mit akarsz csinálni:");
            for (int i = 1; i < lehetosegek.Length + 1; i++)
            {
                if (currentLocation.ChosenOptions[i - 1])
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine($"{i}. - {lehetosegek[i - 1]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            int choice;
            bool error = false;
            while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out choice) || (choice < 1 || choice > lehetosegek.Length || currentLocation.ChosenOptions[choice-1]))
            {
                if (!error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ilyet nem tudsz csinálni!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Próbáld újra!");
                    error = true;
                }
            }
            currentLocation.ChosenOptions[choice - 1] = true;
            return choice - 1;
        }
        public static int basic(ref LocationData currentLocation)
        {
            return 0;
        }
    }
}
