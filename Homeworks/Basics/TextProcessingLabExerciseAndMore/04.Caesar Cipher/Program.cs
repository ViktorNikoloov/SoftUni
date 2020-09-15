using System;

namespace _04.Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string newText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                newText += (char)(text[i] + 3);
            }

            Console.WriteLine(newText);
        }
    }
}
