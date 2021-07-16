using System;
using System.IO;
using System.Linq;

namespace Task2
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


            // Разбиваем текст на отдельные слова без знаков пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var delimiters = new char[] { ' ', '\n', '\r' };
            var words = noPunctuationText.ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Группируем слова по частоте встречаемости
            var wordGroups1 = from a in words
                              group a by a into b
                              select new { b.Key, Count = b.Count() } into c
                              orderby c.Count descending
                              select c;

            var wordGroups2 = words.GroupBy(a => a).Select(b => new { b.Key, Count = b.Count() }).OrderByDescending(c => c.Count);

            // Выводим 10 самых часто встречающихся слов
            Console.WriteLine("10 самых часто встречающихся слов: ");
            Console.WriteLine("(слово - количество раз)");
            foreach (var word in wordGroups1.Take(10))
            {
                Console.WriteLine($"{word.Key} - {word.Count}");
            }
        }
    }
}
