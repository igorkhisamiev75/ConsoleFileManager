using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFileManager
{
    class DataHourandMinClass
    {
        DateTime now = DateTime.Now;

        public void DrawTime()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(140, 1);
            Console.WriteLine("{0:t}", now);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
