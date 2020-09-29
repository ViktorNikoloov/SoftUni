using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> occurrences = new Dictionary<char, int>();
            char[] characters = Console.ReadLine().ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                char currChar = characters[i];
                if (!occurrences.ContainsKey(currChar))
                {
                    occurrences.Add(currChar, 1);
                }
                else
                {
                    occurrences[currChar]++;
                }
            }
            var sortedOccurrences = occurrences.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var symbol in sortedOccurrences)
            {
                if (!(char.IsUpper(symbol.Key) || char.IsLower(symbol.Key)))
                {
                    Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");

                }
            }
            foreach (var symbol in sortedOccurrences)
            {
                if (char.IsUpper(symbol.Key))
                {
                    Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");

                }
            }
            foreach (var symbol in sortedOccurrences)
            {
                if (char.IsLower(symbol.Key))
                {
                    Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");

                }
            }


        }
    }
}
