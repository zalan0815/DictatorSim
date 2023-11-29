using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class SlowPrintSystem
    {
        private static bool isPrintStopped = false;
        private static bool isPrintInProgress = false;
        private static int lasti = 0;
        public static int printLenght = Console.WindowWidth - 30;

        public static SlowPrintSystem frame = new SlowPrintSystem();

        public static void SlowPrint(string text)
        {
            int i = 0;
            lasti = 0;

            while (isPrintInProgress && !isPrintStopped)
            {
                Thread.Sleep(10);
            }
            frame.slowPrint2(i, text);

            isPrintInProgress = true;
            Console.ReadKey(true);

            isPrintStopped = true;

            i = lasti;

            if (i < text.Length)
            {
                while (i < text.Length)
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
                    }
                    else
                    {
                        Console.Write(text[i]);
                    }
                    i++;
                }
            }
            Console.WriteLine();
            lasti = 0;
            isPrintStopped = false;
        }

        private async Task slowPrint2(int i, string text)
        {
            await Task.Run(() =>
            {
                while (i < text.Length)
                {
                    if (isPrintStopped)
                    {
                        break;
                    }
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
                    if (isPrintStopped)
                    {
                        break;
                    }
                    i++;
                    lasti = i + 1;
                }
                isPrintInProgress = false;
            });
        }
    }
}
