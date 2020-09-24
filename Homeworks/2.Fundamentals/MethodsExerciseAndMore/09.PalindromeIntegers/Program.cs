using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
           // string text = input.ToString();

            while (text != "END")
            {
                PalindromeIntegers(text);

                text = Console.ReadLine();
            }
        }

        static void PalindromeIntegers(string text)
        {
            string reverseText = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverseText += text[i];
            }

            if (text == reverseText)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
