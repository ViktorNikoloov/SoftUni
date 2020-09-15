using System;

namespace _004.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            for (int i = 0; i < bannWords.Length; i++)
            {
                text = text.Replace(bannWords[i], new string('*', bannWords[i].Length));
            }

            Console.WriteLine(text);
        }
    }
}
