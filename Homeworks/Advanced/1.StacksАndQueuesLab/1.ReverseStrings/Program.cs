using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedText = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reversedText.Push(input[i]);
            }

            Console.WriteLine(string.Join("", reversedText));

           


        }
    }
}
