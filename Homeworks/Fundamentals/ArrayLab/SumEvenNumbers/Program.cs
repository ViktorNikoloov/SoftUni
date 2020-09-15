using System;
using System.Linq;

namespace SumEvenNumbers
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
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] % 2 == 0)
                {
                    sum += num[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
