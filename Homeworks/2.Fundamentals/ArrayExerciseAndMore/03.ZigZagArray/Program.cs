using System;

namespace _03.ZigZagArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArr = new int[n];
            int[] secondArr = new int[n];
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Split();
                if (counter % 2 == 0)
                {
                    firstArr[i] = int.Parse(numbers[0]);
                    secondArr[i] = int.Parse(numbers[1]);
                }
                else
                {
                    firstArr[i] = int.Parse(numbers[1]);
                    secondArr[i] = int.Parse(numbers[0]);
                }
                counter++;
            }
            Console.WriteLine(String.Join(" ", firstArr));
            Console.WriteLine(String.Join(" ", secondArr));
        }
    }
}
