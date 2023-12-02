using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    class SlowPrintSystem
    {
        private static bool isPrintSkip = false;
        public static void SlowPrint(string text, int printms=25)
        {
            Thread printer = new Thread(() => SlowPrintHandler(text, printms));

            isPrintSkip = false;
            printer.Start();

            Console.ReadKey(true);
            isPrintSkip = true;
            printer.Join();

        }
        public static void SlowPrintLine(string text, int printms = 25)
        {
            SlowPrint(text, printms);
            Console.WriteLine();
        }

        private static void SlowPrintHandler(string text, int printms)
        {
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {

                if (words[i].Length >= Program.printLenght - Console.CursorLeft && !(words[i].Length >= Program.printLenght))
                {
                    Console.WriteLine();
                }
                if (i < words.Length - 1)
                {
                    words[i] += " ";
                }

                SlowPrintWord(words[i], printms);

            }
        }

        private static void SlowPrintWord(string word, int printms)
        {
            int cursorPostion = Console.CursorLeft;
            for (int i = 0; i < word.Length; i++)
            {
                if (cursorPostion >= Program.printLenght - 1)
                {
                    Console.Write("-");
                    Console.WriteLine();
                }
                Console.Write(word[i]);
                cursorPostion++;

                Thread.Sleep(isPrintSkip ? 0 : printms);

            }
            
        }
    }
}
