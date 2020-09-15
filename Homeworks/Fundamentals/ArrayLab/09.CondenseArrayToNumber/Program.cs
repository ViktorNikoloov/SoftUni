using System;
using System.Linq;

namespace _09.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            while (numbers.Length != 1)
            {
                int[] newarr = new int[numbers.Length - 1];
                
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    newarr[i] = numbers[i] + numbers[i + 1];
                }
                numbers = newarr;
            }

            Console.WriteLine(numbers[0]);
        }
    }
}
