using System;
using System.IO;

namespace _2_file
{//Создайте файл, запишите в него произвольные данные и закройте файл. Затем снова откройте
  //  этот файл, прочитайте из него данные и выведете их на консоль.
    class Program
    {
        static void Main(string[] args)
        {
            // Создание файла.
            FileStream file = File.Create(@"D:\test.txt"); //метод Create возвращает уже поток
            var writer = new StreamWriter(file);           //конфигурируем поток на запись
            writer.WriteLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
            writer.Close(); //Отлично
            file.Close();   //Отлично


            Console.WriteLine("Hello World!");

            string filepath = @"D:\test.txt"; 

            //string path = "" + filepath;

            FileStream file1 = File.Open(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var reader = new StreamReader(file1); //конфигурируем поток на чтение
            Console.Write(reader.ReadToEnd());  // Читаем до конца 
            reader.Close(); //Отлично
//Отлично   //file.Close(); // Закрывать не обязательно так как reader закроет сам.
            Console.WriteLine("Для удаления нажмите любую кнопку");
            Console.ReadKey();
            File.Delete(filepath);
            Console.WriteLine("Файл удален");
            Console.ReadKey();
        }
    }
}
