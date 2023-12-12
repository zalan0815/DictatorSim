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
        
        public DeerGame()
        {
            cought = false;
            visiable = false;
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
                    break;
                }
            }
        }
        private void Logic()
        {
            Random r = new Random();
            while (!cought)
            {
                Thread.Sleep(r.Next(0,5));
                visiable = true;
                Thread.Sleep(r.Next(0, 5));
                visiable = false;
            }
        }
    }
}
