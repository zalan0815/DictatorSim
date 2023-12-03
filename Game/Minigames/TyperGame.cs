using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game.Minigames
{
    class TyperGame
    {
        private Player player;
        private string text;
        private char[] playerText;

        Regex reg = new Regex("^[a-zA-Z]+$");

        public TyperGame(Player player, string text)
        {
            this.player = player;
            this.text = text;
        }
        public void Run()
        {
            ResetCursor();
            Color(text, ConsoleColor.DarkGray);
            ResetCursor();

            char key;
            int cursor;
            playerText = text.ToCharArray();

            for (int i = 0; i < playerText.Length; i++)
            {
                playerText[i] = ' ';
            }

            while (true)
            {
                key = Console.ReadKey(true).KeyChar;
                cursor = Console.CursorLeft;

                if(cursor - 1 >= 0)
                {
                    if (key == ' ' && cursor < text.Length)
                    {
                        if (text[cursor - 1] != ' ')
                        {
                            Console.CursorLeft = text.IndexOf(' ', cursor) + 1;
                        }
                        continue;
                    }

                    if (key == (char)8) //backspace
                    {
                        if (text[cursor - 1] == ' ')
                        {
                            bool notRightChar = false;
                            int cursorDef = Console.CursorLeft - 1;

                            cursor--;
                            while (cursor >= 0)
                            {
                                if (text[cursor] != playerText[cursor])
                                {
                                    notRightChar = true;
                                    break;
                                }
                                cursor--;
                            }

                            cursor = cursorDef;

                            if (notRightChar)
                            {
                                while(cursor >= 0 && playerText[cursor] == ' ')
                                {
                                    cursor--;
                                }
                                Console.CursorLeft = cursor + 1;

                            }
                            

                        }
                        else
                        {
                            Console.CursorLeft -= 1;
                            cursor -= 1;
                            Color(text[cursor], ConsoleColor.DarkGray);
                            Console.CursorLeft -= 1;

                            playerText[cursor] = ' ';
                        }

                        continue;
                    }
                }
                
                if (cursor < text.Length && reg.Match(key.ToString()).Success)
                {
                    Color(key, text[cursor] == key ? ConsoleColor.White : ConsoleColor.Red);
                    playerText[cursor] = key;

                    continue;
                }
                

            }
        }
        private void Color(char chr, ConsoleColor color)
        {
            Color(chr.ToString(), color);
        }
        private void Color(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void ResetCursor()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
        }
    }
}
