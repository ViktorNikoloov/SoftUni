using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            int numSum = 0;

            while (numbers != "Stop")
            {
                int num = int.Parse(numbers);
                numSum += num;

                numbers = Console.ReadLine();
            }

            Console.WriteLine(numSum);
        }
    }
}
