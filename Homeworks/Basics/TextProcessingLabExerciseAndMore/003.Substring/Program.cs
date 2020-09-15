using System;

namespace _003.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string text = Console.ReadLine();
            int startIndex = text.IndexOf(word);

            while  (text.Contains(word)) //(text.IndexOf(word) != -1)
            {
                text = text.Remove(startIndex, word.Length);
                startIndex = text.IndexOf(word);
            }

            Console.WriteLine(text);
        }
    }
}
