using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            double average = Average(input);
            //double average = input.Average();
            int maxValue = TheBigestNumber(input);
            //int maxValue = input.Max();
            List<int> finalNumbers = new List<int>();
            input.Sort();
            input.Reverse();

            for (int i = 0; i < input.Count; i++)
            {
                if (finalNumbers.Count == 5)
                {
                    break;
                }
                if (input[i] > average && input[i] <= maxValue)
                {
                    finalNumbers.Add(input[i]);
                }
            }

            if (finalNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", finalNumbers));
            }

        }

        static double Average(List<int> numbers)
        {
            double sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            double average = Math.Round(sum / numbers.Count, 2);
            return average;
        }

        static int TheBigestNumber(List<int> numbers)
        {
            int theBiggestNumber = int.MinValue;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > theBiggestNumber)
                {
                    theBiggestNumber = numbers[i];
                }
            }

            return theBiggestNumber;
        }
    }
}
