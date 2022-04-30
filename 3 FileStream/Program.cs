using System;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace _3_FileStream
{//  Напишите приложение для поиска заданного файла на диске. Добавьте код, использующий
 //  класс FileStream и позволяющий просматривать файл в текстовом окне.В заключение
 //  добавьте возможность сжатия найденного файла.

    //В каждой папке 1-м циклом проходим по всем файлам и 2-м циклом заходим в следующий путь.
    //По мере углубления по дереву каталогов, тиражируем танные в стеке
    class Program
    {
        static void Search(DirectoryInfo dr, Regex file)
        {
            FileInfo[] fi = dr.GetFiles();   // возвращает массив файлов в текущей папке
            foreach (FileInfo info in fi)    // для каждого блока информации о файле  во всем массиве файлов
            {
                if (file.IsMatch(info.Name)) // проверка соответствия имени файла модели, которая пришла на вход
                {
                    Console.WriteLine("--------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Текущая папка, в которой найден файл, соответствующий модели :\n {0}", dr.FullName);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("{0}", info.Name); //info.Directory.FullName,

                   
                    PrintFile(info.Directory.FullName); //передаем полное имя файла для чтения
                    ZipFile(info.Directory.FullName); //Отлично

                    Console.WriteLine("--------------");
                }
            }

            DirectoryInfo[] dirs = dr.GetDirectories(); // получили поддиректории текущей папки
                                                        // метод возвращает массив поддиректорий в папке, на которой вызывается
            foreach (DirectoryInfo directoryInfo in dirs) // для каждого блока информации о папке  во всем массиве папок
            {                                             //следующая папка будет первая из полученного списка поддиректорий
                Search(directoryInfo, file);
            }
        }

        static void PrintFile(string filepath)
        {
            //string path = "@" + """ + filepath + """;
            Console.WriteLine($"контрольный вывод пути {filepath}");
            FileStream file2 = File.Open(filepath, FileMode.Open, FileAccess.Read);
            var reader = new StreamReader(file2); //конфигурируем поток на чтение
            Console.Write(reader.ReadToEnd());  // Читаем до конца 
            reader.Close();
            //file.Close(); // Закрывать не обязательно так как reader закроет сам.
        }

        static void ZipFile(string filepath)
        {
            Console.WriteLine($"контрольный вывод пути Zip {filepath}"); //Отлично
            FileStream file2 = File.OpenRead(filepath);
            FileStream destination = File.Create(@"C:\archive.zip");// целевой файл

/*Отлично*/ GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);// Создание компрессора. принимает файл назначения

            // Заполнение архива информацией из файла.
            int theByte = file2.ReadByte();// читаем байтики
            while (theByte != -1)
            {
                compressor.WriteByte((byte)theByte);// компрессор, читай байтик
                /*Отлично*/
                theByte = file2.ReadByte();// снова читаем из источника 
            }
            compressor.Close(); // Удаление компрессора.
        }
        static void Main(string[] args)
        {
            Regex file = new Regex(@".+[.]cs$");
            DirectoryInfo dr = new DirectoryInfo(@"C:\repos");
            Search(dr, file); /*Отлично*/
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
