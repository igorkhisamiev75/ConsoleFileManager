using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFileManager
{
    class TextOnTopFrame
    {
        int x, y; // точки для указания начальной строки
        string text;
        public TextOnTopFrame(int _x, int _y, string _text)
        {
            x = _x;
            y = _y;
            text = _text;

        }

        public void DrawText()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

        }
    }
}
