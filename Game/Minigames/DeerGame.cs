using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Minigames
{
    public class DeerGame
    {
        private static string asciiDeer = "     /|    |\\\r\n  `__\\\\    //__'\r\n   _.,:---;,._\r\n   \\_:     :_/\r\n     |@. .@|\r\n     |     |\r\n      \\.-./ \\\r\n      ;`-'   `---__________-----.-.\r\n      ;;;                        \\_\\\r\n       \\   \\     \\        |      /\r\n        \\_, \\    /        \\     |\\\r\n          |';|  |,,,,,,,,/ \\    \\ \\_\r\n          |  |  |           \\   /   |\r\n          \\  \\  |           |  / \\  |\r\n           | || |           | |   | |\r\n           | || |           | |   | |\r\n           |_||_|           |_|   |_|\r\n          /_//_/           /_/   /_/";
        private bool cought;
        private bool visiable;
        private bool badShot;
        
        public DeerGame()
        {
            cought = false;
            visiable = false;
            badShot = false;
        }

        public void Run()
        {
            Thread logic = new Thread(Logic);
            logic.Start();
            while (!cought)
            {
                Console.ReadKey(true);
                if(visiable)
                {
                    cought = true;
                    logic.Join();
                    break;
                }
                else
                {
                    badShot = true;
                }
            }
            Console.Clear();
            Program.PrintPlayerStat();
        }
        private void Logic()
        {
            Random r = new Random();
            while (!cought)
            {
                Console.Clear();
                Program.PrintPlayerStat();
                Console.WriteLine("Nyomj le egy gombot a Csodaszarvas elejtéséhez!\n");
                if (visiable)
                {
                    Console.Write(asciiDeer);
                    Console.SetCursorPosition(0, 1);
                    Thread.Sleep(r.Next(200, 600));
                }
                else
                {
                    Console.SetCursorPosition(0, 1);
                    do
                    {
                        badShot = false;
                        Thread.Sleep(r.Next(1800, 3500));
                    }
                    while (badShot);
                }
                visiable = !visiable;
                
            }
        }
    }
}
