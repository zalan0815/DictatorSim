using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class MiningGame
    {
        private int yTop = 5;
        private int xMax;
        private int yMax;
        private int widthSize = 2; //map bal-jobb szélének mérete

        private int diaPosx;
        private int diaPosy;

        public void Mining(char ko, char dia)
        {
            printMiningMapBase();
            PrintMine(ko, dia);

            Console.WriteLine($"\nBánya - NYILAK-kal keresd meg és ENTER-el bányászd ki a gyémántot! Kilépéshez nyomd meg a 0-t. (kövek: {ko}, gyémánt: {dia})");

            SearchForDiamond();
        }

        private void printMiningMapBase()
        {
            int longest = "életerőd".Length;
            xMax = Console.WindowWidth - longest - 4;
            yMax = Console.WindowHeight - 3;

            Console.BackgroundColor = ConsoleColor.White;

            Console.CursorLeft = 0;
            Console.CursorTop = yTop;
            Console.Write(new string(' ', xMax + widthSize));

            Console.CursorLeft = 0;
            Console.CursorTop = yMax;
            Console.Write(new string(' ', xMax + widthSize));

            for (int j = 1; j < yMax - yTop; j++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = yTop + j;
                Console.Write(new string(' ', widthSize));
                Console.CursorLeft = xMax;
                Console.Write(new string(' ', widthSize));
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void PrintMine(char ko, char dia)
        {
            Random random = new Random();

            Console.ForegroundColor = ConsoleColor.White;

            for (int j = 1; j < yMax - yTop; j++)
            {
                Console.CursorLeft = widthSize;
                Console.CursorTop = yTop + j;
                Console.Write(new string(ko, xMax - widthSize));
            }

            diaPosx = random.Next(widthSize + 2, xMax - widthSize - 2);
            diaPosy = random.Next(yTop + 2, yMax - 2);

            Console.CursorLeft = diaPosx;
            Console.CursorTop = diaPosy;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(dia);
            Console.ForegroundColor = ConsoleColor.White;

            Console.CursorTop = yMax;
        }

        private void SearchForDiamond()
        {
            bool found = false;
            bool mining = true;
            ConsoleKey input;

            int cursorPosX = widthSize;
            int cursorPosY = ++yTop;

            Console.CursorLeft = cursorPosX;
            Console.CursorTop = cursorPosY;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write('a');
            Console.CursorLeft = cursorPosX;
            Console.CursorTop = cursorPosY;

            while (mining)
            { 
                input = Console.ReadKey(true).Key;

                if (cursorPosX == diaPosx && cursorPosY == diaPosy)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('x');
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('a');
                }

                switch (input)
                {
                    case ConsoleKey.LeftArrow:
                        cursorPosX--;
                        break;
                    case ConsoleKey.UpArrow:
                        cursorPosY--;
                        break;
                    case ConsoleKey.RightArrow:
                        cursorPosX++;
                        break;
                    case ConsoleKey.DownArrow:
                        cursorPosY++;
                        break;
                    case ConsoleKey.Enter:
                        if (cursorPosX == diaPosx && cursorPosY == diaPosy)
                        {
                            found = true;
                            mining = false;
                        }
                        break;
                    case ConsoleKey.D0:
                        mining = false;
                        break;
                }

                if (cursorPosX == diaPosx && cursorPosY == diaPosy)
                {
                    Console.CursorLeft = cursorPosX;
                    Console.CursorTop = cursorPosY;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write('x');
                    Console.CursorLeft = cursorPosX;
                    Console.CursorTop = cursorPosY;
                }
                else
                {
                    Console.CursorLeft = cursorPosX;
                    Console.CursorTop = cursorPosY;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write('a');
                    Console.CursorLeft = cursorPosX;
                    Console.CursorTop = cursorPosY;
                }
            }
            Console.CursorTop = yMax;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
