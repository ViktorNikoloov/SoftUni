using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= input; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                sum += numbers;


            }

            Console.WriteLine(sum);
        }
    }
}
