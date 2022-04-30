using System;
using System.IO;

namespace add
{//Создайте на диске 100 директорий с именами от Folder_0 до Folder_99, затем удалите их.
    class Program
    {
        static void Main(string[] args)
        {
            // 1 способ создания 
            Directory.CreateDirectory(@"C:\Z DIR");
            var directory = new DirectoryInfo(@"C:\Z DIR");
            Console.WriteLine(directory.FullName);
            
            if (directory.Exists)
            {
                for (int i = 0; i < 100; i++)
                {
                    directory.CreateSubdirectory($"Folder_{i}");
                }
                Console.WriteLine("Директории созданы.");
            }
            else
            {
                Console.WriteLine("Директория с именем: {0}  не существует.", directory.FullName);
            }

            //// 2 способ создания
            //for (int i = 0; i < 100; i++)
            //{
            //    Directory.CreateDirectory($"C:\\Z DIR\\Folder_{i}");
            //}


            Console.WriteLine("Нажмите для удаления папок Folder_0 ... Folder_99");
            Console.ReadKey();
            
            
            // 1 способ удаления
            //for (int i = 0; i < 100; i++)
            //{
            //    Directory.Delete($"C:\\Z DIR\\Folder_{i}");
            //}

            // 2 способ удаления
            foreach (string folder in Directory.GetDirectories(@"C:\Z DIR"))
            {
                Directory.Delete(folder, true);
            }

            // удалит всю директорию Z DIR
            //directory.Delete(true);

            Console.WriteLine("Директории удалены");

            // Delay.
            Console.ReadKey();
        }
    }
}
