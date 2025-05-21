using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string fileName = "input.txt";

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Файл '{fileName}' не знайдено.");
            return;
        }

        // Черги для голосних і приголосних
        Queue<string> vowelsQueue = new Queue<string>();
        Queue<string> consonantsQueue = new Queue<string>();

        // Голосні українські (додавай або змінюй для іншої мови)
        string vowels = "аеєиіїоуюяAEЄИІЇОУЮЯaeiouAEIOU";

        // Читаємо файл построчно
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Розбиваємо рядок на слова (літери, цифри)
                string[] words = Regex.Split(line, @"\W+");

                foreach (string word in words)
                {
                    if (string.IsNullOrWhiteSpace(word)) continue;

                    char firstChar = word[0];

                    if (vowels.IndexOf(firstChar) >= 0)
                        vowelsQueue.Enqueue(word);
                    else
                        consonantsQueue.Enqueue(word);
                }
            }
        }

        // Виводимо спочатку голосні
        Console.WriteLine("Слова, що починаються на голосну:");
        while (vowelsQueue.Count > 0)
        {
            Console.Write(vowelsQueue.Dequeue() + " ");
        }
        Console.WriteLine();

        // Потім приголосні
        Console.WriteLine("Слова, що починаються на приголосну:");
        while (consonantsQueue.Count > 0)
        {
            Console.Write(consonantsQueue.Dequeue() + " ");
        }
        Console.WriteLine();
    }
}
