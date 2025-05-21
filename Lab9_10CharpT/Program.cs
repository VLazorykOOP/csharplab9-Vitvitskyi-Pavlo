using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string fileName = "t.txt";

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Файл '{fileName}' не знайдено.");
            return;
        }

        // Зчитування всіх рядків
        string[] lines = File.ReadAllLines(fileName);

        List<Task> tasks = new List<Task>();

        // Створення задачі для кожного рядка
        for (int i = 0; i < lines.Length; i++)
        {
            int lineIndex = i; // локальна копія для замикання
            tasks.Add(Task.Run(() =>
            {
                string reversed = ReverseLineWithStack(lines[lineIndex]);
                Console.WriteLine($"Рядок {lineIndex + 1}: {reversed}");
            }));
        }

        // Очікуємо завершення всіх задач
        Task.WaitAll(tasks.ToArray());

        Console.WriteLine("Обробка завершена.");
    }

    // Метод перевертання рядка за допомогою Stack
    static string ReverseLineWithStack(string line)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in line)
        {
            stack.Push(c);
        }

        char[] reversed = new char[stack.Count];
        int index = 0;
        while (stack.Count > 0)
        {
            reversed[index++] = stack.Pop();
        }

        return new string(reversed);
    }
}
