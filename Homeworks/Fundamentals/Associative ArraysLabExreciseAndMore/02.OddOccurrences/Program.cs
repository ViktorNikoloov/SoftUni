using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var item in input)
            {
                string toLower = item.ToLower();
                if (!counts.ContainsKey(toLower))
                {
                    counts.Add(toLower, 1);
                }
                else
                {
                    counts[toLower]++;
                }

            }

            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}
