using System;

namespace AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double totalSum = 0;
            for (int i = 0; i < input; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                totalSum += numbers;
            }
            Console.WriteLine($"{totalSum / input:f2}");
        }
    }
}
