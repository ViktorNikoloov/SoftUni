using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            SortedDictionary<double, int> sortedNumbers = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!sortedNumbers.ContainsKey(number))
                {
                    sortedNumbers.Add(number, 1);
                }
                else
                {
                    sortedNumbers[number]++;
                }
            }

            foreach (var number in sortedNumbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
