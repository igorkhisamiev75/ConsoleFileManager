using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFileManager
{
    class ConteinerClass
    {
        int x, y; // точки для указания начальной строки

        public int lenghString; // длина строки
        public int numLines; // колличество строк в столбце
        
        public int columns; //номер нашего контейнера
        public string[] dataName; // имена для заполнения(имя файла или папки)

        Array arraySource;
        decimal countPage; //номер страницы

        public ConteinerClass(int _x, int _y, int _lenghString, int _columns, Array _arraySource, decimal _countPage)
            {
            x = _x;
            y = _y;
            lenghString = _lenghString;
            columns = _columns;
            //dataName = _dataName;
            arraySource = _arraySource;
            countPage = _countPage;

        }

        public void DrawContainer()
        {
            Console.SetCursorPosition(x*columns, y);
            for (int i = 0; i < arraySource.Length; i++)
            {
                Console.WriteLine(arraySource.GetValue(i));
                Console.SetCursorPosition(x* columns, y + i);
            }
        }

    }
}
