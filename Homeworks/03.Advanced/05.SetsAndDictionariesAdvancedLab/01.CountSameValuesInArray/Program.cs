using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> occurrences = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currNum = numbers[i];
                if (!occurrences.ContainsKey(currNum))
                {
                    occurrences.Add(currNum, 1);
                }
                else
                {
                    occurrences[currNum]++;
                }
            }

            foreach (var number in occurrences)
            {
                Console.WriteLine($"{number.Key} - {number.Value } times");
            }
        }
    }
}
