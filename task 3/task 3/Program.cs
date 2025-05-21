using System;
using System.Collections;
using System.IO;

class Task1
{
    static void Main()
    {
        string file1 = "t1.txt";

        // Виправлена дужка тут
        if (!File.Exists(file1))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        ArrayList lines = new ArrayList();
        lines.AddRange(File.ReadAllLines(file1));

        Console.WriteLine("Задача 1: Рядки у зворотному порядку символів:");

        // Використання IEnumerable для ітерування ArrayList
        foreach (string line in lines)
        {
            Console.WriteLine(ReverseWithStack(line));
        }
    }

    static string ReverseWithStack(string line)
    {
        Stack stack = new Stack();
        foreach (char c in line)
            stack.Push(c);

        char[] reversed = new char[stack.Count];
        int i = 0;
        while (stack.Count > 0)
            reversed[i++] = (char)stack.Pop();

        return new string(reversed);
    }
}
