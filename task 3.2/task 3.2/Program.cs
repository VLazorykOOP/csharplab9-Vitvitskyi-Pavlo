using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

class Task2
{
    static void Main()
    {
        string file1 = "t1.txt";


        if (!File.Exists(file1))
        {
            Console.WriteLine("файл не знайдений.");
            return;
        }

        ArrayList lines = new ArrayList();
        lines.AddRange(File.ReadAllLines(file1));
 

        ArrayList allWords = new ArrayList();
        foreach (string line in lines)
        {
            string[] words = Regex.Split(line, @"\W+");
            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                    allWords.Add(word);
            }
        }

        WordCollection wordsCollection = new WordCollection(allWords);
        WordCollection clonedCollection = (WordCollection)wordsCollection.Clone();

        Console.WriteLine("Задача 2: Слова, спочатку на голосну, потім на приголосну:");
        clonedCollection.PrintVowelsThenConsonants();
    }
}

class WordCollection : IEnumerable, IComparer, ICloneable
{
    private ArrayList words;
    private string vowels = "аеєиіїоуюяAEЄИІЇОУЮЯaeiouAEIOU";

    public WordCollection(ArrayList words)
    {
        this.words = (ArrayList)words.Clone();
    }

    public IEnumerator GetEnumerator()
    {
        return words.GetEnumerator();
    }

    public object Clone()
    {
        return new WordCollection((ArrayList)this.words.Clone());
    }

    public int Compare(object x, object y)
    {
        return string.Compare(x as string, y as string, StringComparison.CurrentCultureIgnoreCase);
    }

    public void PrintVowelsThenConsonants()
    {
        ArrayList vowelsList = new ArrayList();
        ArrayList consonantsList = new ArrayList();

        foreach (string word in words)
        {
            if (word.Length == 0) continue;

            if (vowels.IndexOf(word[0]) >= 0)
                vowelsList.Add(word);
            else
                consonantsList.Add(word);
        }

        foreach (string w in vowelsList)
            Console.Write(w + " ");
        foreach (string w in consonantsList)
            Console.Write(w + " ");

        Console.WriteLine();
    }
}
