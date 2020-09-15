using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Console.WriteLine(Print(text));
        }

        static string Print(string text)
        {
            string output = "";

            if (text.Length % 2 == 0)
            {
                output += text[(text.Length - 1) / 2];
                output += text[(text.Length / 2)];
            }
            else
            {
                output += text[text.Length / 2];
            }
            return output;
        }
    }
}
