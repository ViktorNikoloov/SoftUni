using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] strings = Console.ReadLine().Split();
            //int[] numbers = new int[strings.Length];
            //for (int i = 0; i < strings.Length; i++)
            //{
            //    numbers[i] = int.Parse(strings[i]);
            //}
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenSum += numbers[i];
                }
                else
                {
                    oddSum += numbers[i];
                }

            }
            Console.WriteLine(evenSum - oddSum);
        }

    }
}
