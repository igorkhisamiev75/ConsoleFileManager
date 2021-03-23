using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFileManager
{
    class CreateFrame
    {
        int X1,  X2, Y1, Y2;
        public CreateFrame(int x1, int x2, int y1, int y2)
        {
           X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;

        }
             
        public void CreatingFrameConsole(int x1, int x2, int y1, int y2)
        {
            char symLeftTopAngle = '╔';
            char symLeftDownAngle = '╚';
            char symRightTopAngle = '╗';
            char symRightDownAngle = '╝';
            char symHor = '═';
            char symVer = '║';
            //отрисовываем верхнюю рамку
            Console.SetCursorPosition(x1, y1);
            Console.Write(symLeftTopAngle);

            HorizontalDrawMethod(x1, x2, symHor);

            Console.Write(symRightTopAngle);

            //отрисовываем нижнюю рамку
            Console.SetCursorPosition(x1, y2);
            Console.Write(symLeftDownAngle);

            HorizontalDrawMethod(x1, x2, symHor);
            Console.Write(symRightDownAngle);

            //отрисовываем левую сторону рамки
            Console.SetCursorPosition(x1, y1 + 1);

            for (int i = 0; i < y2 - y1; i++)
            {
                Console.Write(symVer);
                Console.SetCursorPosition(x1, y1 + 1 + i);
            }

            //отрисовываем правую сторону рамки
            Console.SetCursorPosition(x2, y1 + 1);

            for (int i = 0; i < y2 - y1; i++)
            {
                Console.Write(symVer);
                Console.SetCursorPosition(x2, y1 + 1 + i);
            }
        }

        public static void HorizontalDrawMethod(int x1, int x2, char symHor)
        {
            for (int i = 0; i < x2 - x1 - 1; i++)
            {
                Console.Write(symHor);
            }
        }
    }
}
