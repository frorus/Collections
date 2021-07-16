using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Читаем файл по указанному пути
            Console.WriteLine(@"Введите директорию файла (пример - D:\TestFolder\Text1.txt): ");
            string dirName = Console.ReadLine();

            while (!File.Exists(dirName))
            {
                Console.WriteLine("Файл не найден, попробуйте снова.\n");
                dirName = Console.ReadLine();
            }

            var text = File.ReadAllText(dirName);

            // Преобразуем текст в массив символов
            var characters = text.ToCharArray();

            //Создаем простой список List
            var simpleList = new List<char>(characters);

            //Создаем связанный список LinkedList
            var linkedList = new LinkedList<char>(characters);

            //Проверяем производительность вставки в простой список
            var stopWatch = Stopwatch.StartNew();

            simpleList.Add(Convert.ToChar("j"));
            var simpleListTime = stopWatch.Elapsed.TotalMilliseconds;

            Console.WriteLine($"Время вставки для простого списка {simpleListTime} мс");

            //Провереям производительность вставки в связанный список
            stopWatch = Stopwatch.StartNew();

            linkedList.AddLast(Convert.ToChar("j"));
            var linkedListTime = stopWatch.Elapsed.TotalMilliseconds;

            Console.WriteLine($"Время вставки для связанного списка {linkedListTime} мс");

            //Сравниваем производительности
            if (simpleListTime > linkedListTime)
            {
                Console.WriteLine($"Производительность вставки в связанный список больше в {Math.Round((simpleListTime / linkedListTime), 1)} раз(а)");
            }
            else
            {
                Console.WriteLine($"Производительность вставки в простой список больше в {Math.Round((linkedListTime / simpleListTime), 1)} раз(а)");
            }
        }
    }
}
