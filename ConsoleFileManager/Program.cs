#region Namespaces
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


#endregion
#region Задание
//Общие сведения
//Требуется создать консольный файловый менеджер начального уровня, который покрывает минимальный набор функционала по работе с файлами.
//Функции и требования
//Просмотр файловой структуры
//Поддержка копирование файлов, каталогов
//Поддержка удаление файлов, каталогов
//Получение информации о размерах, системных атрибутов файла, каталога
//Вывод файловой структуры должен быть постраничным
//В конфигурационном файле должна быть настройка вывода количества элементов на страницу
//При выходе должно сохраняться, последнее состояние
//Должны быть комментарии в коде
// Должна быть документация к проекту в формате md
//Приложение должно обрабатывать непредвиденные ситуации (не падать)
//При успешном выполнение предыдущих пунктов – реализовать сохранение ошибки в текстовом файле в каталоге errors/random_name_exception.txt
//При успешном выполнение предыдущих пунктов – реализовать движение по истории команд (стрелочки вверх, вниз)
//Команды должны быть консольного типа, как, например, консоль в Unix или Windows. Соответственно требуется создать парсер команд, который по минимуму использует стандартные методы по строкам.

#endregion

namespace ConsoleFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
#region Рамка
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            int winWidth = 150;
            int winHeight = 51;


            //задем размеры консоли (ширину и высоту)
            Console.WindowWidth = winWidth;
            Console.WindowHeight = winHeight;

            //задаём размеры буферной области
            Console.BufferWidth = winWidth;
            Console.BufferHeight = winHeight;

            
            int x1 = 1;
            int x2 = 149;
            int y1 = 1;
            int y2 = 49;
            CreateFrame frame1 = new CreateFrame(x1, x2, y1, y2);

            frame1.CreatingFrameConsole(x1, x2, y1, y2);
            x1 = 1;
            x2 = 149;
            y1 = 35;
            y2 = 49;
            CreateFrame frame2 = new CreateFrame(x1, x2, y1, y2);

            frame2.CreatingFrameConsole(x1, x2, y1, y2);

            #endregion //создаем рамку

            Console.SetCursorPosition(2, 2);

            string path = @"C:\apache";
            int a = 3; //расстояние между колонками
            int lenghString = 12; //длина строки вывода данных
            int numLines = 30; //максимальное колличество строк в столбце
            string endChar = "░"; 
            int columns = 3; // колличество столбцов

            int maxCountStrings = columns * numLines; //максимальное колличество строк которое можно вывести на страницу
            //char endChar2 = '▶';

            //добавление времени на консоль
            DataHourandMinClass dataHourandMin = new DataHourandMinClass();
            dataHourandMin.DrawTime();

            //добавление пути на верх рамки
            TextOnTopFrame textOnTopFrame = new TextOnTopFrame(8, 1, path);
            textOnTopFrame.DrawText();
            TextOnTopFrame textOnTopFrame2 = new TextOnTopFrame(8, 35, "тут тоже что-то будет");
            textOnTopFrame2.DrawText();

            DirectoryInfo directory = new DirectoryInfo(path);

            DirectoryInfo[] dirArray = directory.GetDirectories(); //массив объектов DirInfo который возвращает все каталоги в папке
            FileInfo[] fileArray = directory.GetFiles(); //массив объектов FileInfo который возвращает все файлы в папке

            List<String> arrays2 = new List<String>();

            string[] arrayNameFileAndDirectories = new string[dirArray.Length+ fileArray.Length]; //создаем массив равный длинне FILE и DIRECTORY

            //заполняем массив значениями из dirArray
            for (int i = 0; i < dirArray.Length; i++)
            {
                arrayNameFileAndDirectories[i]= dirArray[i].Name;
                arrays2.Add(dirArray[i].Name);
            }

            int z = dirArray.Length; 

            //заполняем массив класса Array значениями из fileArray
            for (int i = 0; i < fileArray.Length; i++)
            {
                arrayNameFileAndDirectories[z+i] = fileArray[i].Name;
                arrays2.Add(fileArray[i].Name);
            }

            int nPage; //номер страницы для вывода

            for (int j = 1; j < 5; j++) //выводим массив данных с разбивкой на столбцы
            {
                nPage = j;
                for (int i = (nPage - 1) * numLines; i < numLines * nPage; i++)
                {
                    int g = 0;

                    while (i < arrays2.Count && i < numLines * nPage)
                    {

                        Console.SetCursorPosition((a * nPage + lenghString * (nPage - 1)), 2 + g);
                        Console.WriteLine(ShordData(arrays2[i], lenghString, endChar));
                        g++;
                        i++;
                    }

                }
            }
            //вычисляем колличество страниц которое понадобится для отображения данных
            decimal countPage = Math.Ceiling(Convert.ToDecimal(arrays2.Count) / maxCountStrings);

            



            //int lenghtArray = arrayNameFileAndDirectories.Length; //длина массива данных 

            //Array arraySource = Array.CreateInstance(typeof(String), lenghtArray);

            //for (int i = 0; i < lenghtArray; i++)
            //{
            //    arraySource.SetValue(arrayNameFileAndDirectories[i], i);
            //}

            //Console.SetCursorPosition(5 , 5);

            //Console.WriteLine(arraySource.GetValue(1));





            // //колличество массивов на которое мы разобъем наш главный массив
            // int nMas = Convert.ToInt32((Math.Ceiling(Convert.ToDecimal(lenghtArray) / Convert.ToDecimal(numLines))));

            // //создаем массив класса ConteinerClass равный колличеству страниц для вывода всей информации
            // ConteinerClass[] conteinerArray = new ConteinerClass[nMas];

            // Array myObjArray = Array.CreateInstance(typeof(string), numLines);




            //Array.Copy(arraySource, 0, myObjArray,  0, numLines);

            // List<Array> arrays = new List<Array>();
            // arrays.Add(myObjArray);

            //Array.Copy(arraySource, 3, arrayTarget, 0, 5);

            //for (int i = 0; i < Convert.ToInt32(countPage); i++)
            //{
            //    conteinerArray[i] = new ConteinerClass((colLen + (colLen + lenghString) * (i + 1)), 2, lenghString, i, arraySource, 1);
            //}
            //conteinerArray[1].DrawContainer();         
            //conteinerArray[2].DrawContainer();
            //conteinerArray[3].DrawContainer();

            //string[] masMas = new string[nMas];

            //for (int i = 0; i < nMas; i++)
            //{
            //    masMas[i] = arrayNameFileAndDirectories[1];
            //}

            //ConteinerClass conteiner1 = new ConteinerClass(5,5,10,1, arrayNameFileAndDirectories);

            //conteiner1.DrawContainer();



            //foreach (string s in arrayNameFileAndDirectories)
            //{
            //    Console.WriteLine(s);
            //}

            //for (int i = 0; i < fileInPathArray.Length; i++)
            //{
            //    string fileName = fileInPathArray[i].Name;

            //}

            //foreach (DirectoryInfo directory1 in diArray)
            //{
            //    Console.WriteLine(directory1.Name);
            //}

            //foreach (FileInfo directory1 in FiArray)
            //{
            //    Console.WriteLine(directory1.Name);
            //}

            //DirectoryInfo[] diArray = directory.GetDirectories(); //массив объектов DirInfo который возвращает все каталоги в папке
            //foreach (DirectoryInfo directory1 in diArray)
            //{
            //    Console.WriteLine(directory1.Name);
            //}


            //ListFolderinPath(path); //выводит список папок
            //ListFilePath(path); //выводит список файлов

            //DirectoryInfo dir = new DirectoryInfo(path).GetDirectories();

            //string[] a = Directory.GetDirectories(path);
            //foreach(string fn in a)
            //{
            //    Console.WriteLine(fn);
            //}

            //if (Directory.Exists(path))
            //{
            //    Console.WriteLine("Подкаталоги:");
            //    string[] dirs = Directory.GetDirectories(path);
            //    foreach (string s in dirs)
            //    {
            //        Console.WriteLine(s);
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine("Файлы:");
            //    string[] files = Directory.GetFiles(path);
            //    foreach (string s in files)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}


            //InfoAboutDirectory(path); //вывод информации о каталоге
            //GetInfoFile(path); // получение информации о файле

            //GetFoldersAndFile(path);

            Console.ReadKey();

        }

        public static string ShordData(string s, int lenghString, string endChar)//вывод только по колличеству знаков указанному в lenghtString длиина строки 
        {
            if (s.Length < lenghString)
            {
                return s;
            }
            else
            {
                return (s.Remove(lenghString-1) + endChar);
                //Console.OutputEncoding = Encoding.Unicode; //с этим разобраться, не выводит ▶
                //Console.WriteLine("\u16A4");
            }

        }

        private static FileInfo[] ListFilePath(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] FiArray = directory.GetFiles(); //массив объектов FileInfo который возвращает все файлы в папке
            foreach (FileInfo directory1 in FiArray)
            {
                Console.WriteLine(directory1.Name);
            }
            return FiArray;

        }

        private static DirectoryInfo[] ListFolderinPath(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] diArray = directory.GetDirectories(); //массив объектов DirInfo который возвращает все каталоги в папке
            foreach (DirectoryInfo directory1 in diArray)
            {
                Console.WriteLine(directory1.Name);
            }
            return diArray;
        }

        //CopyFileOldNewPath(oldFile, newFile); //копирование файла из одного места в другое

        //DirInfo(dirName); //получение информации о каталоге

        //GetFoldersAndFile(path);
        //CopyFileAndDirectories(); //копирование файлов и директорий

        // DriveInfoClass();//получение и вывод сведений обо всех дисках в системе

        // GetFolders(path);

        /*  string dirName = "C:\\Первая";*/

        /*
        string oldFile = @"C:\First\hta.txt";
        string newFile = @"C:\First\Second\hta.txt";
        */


        //CreatingFrameConsole(x1, x2, y1, y2, symLeftTopAngle, symLeftDownAngle, symRightTopAngle, symRightDownAngle, symHor, symVer);

        //Console.ReadKey();

        //Console.Clear();



        //CreatingFrameConsole(x1, x2, y1, y2, symLeftTopAngle, symLeftDownAngle, symRightTopAngle, symRightDownAngle, symHor, symVer);

        //Console.ReadKey();


        //DriveInfoClass();

        //string dirName = @"C:\apache";

        //string path = @"C:\apache\Пожтехника_2014_v.5.rvt";




        //DeleteFileMethod(path); //удаление файла

        //DeleteDirMethod(dirName); //удаление директории


        private static void GetInfoFile(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("Путь: {0}", fileInf.DirectoryName);
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);

            }
        }

        private static void DeleteFileMethod(string path)
        {
            FileInfo fileInf = new FileInfo(path);

            if (fileInf.Exists)
            {
                fileInf.Delete();
                Console.WriteLine("Файл удален");
                // альтернатива с помощью класса File
                // File.Delete(path);
            }
        }

        private static void DeleteDirMethod(string dirName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                dirInfo.Delete(true);
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CopyFileAndDirectories()
        {
            string fileName = "test.txt";
            string sourcePath = @"C:\Users\Public\TestFolder";
            string targetPath = @"C:\Users\Public\TestFolder\SubDir";

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            Directory.CreateDirectory(targetPath);

            File.Copy(sourceFile, destFile, true);

            //копирование всех файлов
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        private static void CopyFileOldNewPath(string oldFile, string newFile)
        {
            FileInfo fileInf = new FileInfo(oldFile);

            if (fileInf.Exists)
            {
                fileInf.CopyTo(newFile, true);

            }
        }

        private static void DirInfo(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
        }

        private static void DirInfoGet(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
        }

        private static void GetFoldersAndFile(string path)
        {
            if (Directory.Exists(path)) //определяет существует ли данный каталог
            {
                //Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(path);
                
                foreach (string s in dirs)
                {
                    Console.WriteLine(s); //перечисления папок
                }
                
                //Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(path);
                foreach (string s in files)
                {
                    Console.WriteLine(s); //перечисления файлов
                }

            }
        }

        private static void InfoAboutDirectory(string path)
        {
            DirectoryInfo dir1 = new DirectoryInfo(path);

            Console.WriteLine("FullName: {0}", dir1.FullName);
            Console.WriteLine("Name: {0}", dir1.Name);
            Console.WriteLine("Parent: {0}", dir1.Parent);
            Console.WriteLine("Creation: {0}", dir1.CreationTime);
            Console.WriteLine("Attributes: {0}", dir1.Attributes);
            Console.WriteLine("Root: {0}", dir1.Root);
        }

        private static void DriveInfoClass()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("Drive type: {0}", d.DriveType);

                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("  Total available space:{0, 15} bytes", d.TotalFreeSpace);
                    Console.WriteLine("  Total size of drive:{0, 15} bytes ", d.TotalSize);
                }
            }
        }

        private static void GetFolders(string path)
        {
            string[] allfiles2 = Directory.GetDirectories(path); // получаем массив всех папок в папке пути

            int i = allfiles2.Length; //получение длины массива

            for (int j = 0; j <= i - 1; j++)
            {
                Console.Write($"{path}\n"); //выводим путь

                GetFolders(allfiles2[j]);
                Console.Write($"\t{allfiles2[j]}\n");
            }
        }

        private static void ConsoleFrame(int winWidth, int winHeight, char sym)
        {
            
        }


        private static void CreatingFrameConsole(int x1, int x2, int y1, int y2, char symLeftTopAngle, char symLeftDownAngle, char symRightTopAngle, char symRightDownAngle, char symHor, char symVer)
        {
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

        private static void HorizontalDrawMethod(int x1, int x2, char symHor)
        {
            for (int i = 0; i < x2 - x1 - 1; i++)
            {
                Console.Write(symHor);
            }
        }

    }

}
