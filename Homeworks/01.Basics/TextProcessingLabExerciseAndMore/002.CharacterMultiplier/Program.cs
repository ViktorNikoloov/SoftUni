using System;
using System.Collections.Generic;

namespace _002.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Console.WriteLine(CharMultiplier(words[0], words[1]));
        }

        static int CharMultiplier(string first, string second)
        {
            int sum = 0;

            string biggest = string.Empty;
            string smaller = string.Empty;

            if (first.Length > second.Length)
            {
                biggest = first;
                smaller = second;
            }
            else
            {
                biggest = second;
                smaller = first;
            }

            for (int i = 0; i < smaller.Length; i++)
            {
                sum += biggest[i] * smaller[i];
            }

            for (int g = smaller.Length; g < biggest.Length; g++)
            {
                sum += biggest[g];
            }

            return sum;
        }
    }
}
