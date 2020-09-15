using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            double payment = double.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int i = 0; i < payment; i++)
            {
                double sum = double.Parse(Console.ReadLine());
                if (sum < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                totalSum += sum;
                Console.WriteLine($"Increase: {sum:f2}");

            }

            Console.WriteLine($"Total: {totalSum}");
        }
    }
}
