using System;

namespace MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            double output = 0;
            for (int i = 0; i < double.MaxValue; i++)
            {
                double numbers = double.Parse(Console.ReadLine());
                if (numbers < 0)
                {
                    Console.WriteLine("Negative number!");
                    break;
                }
                else
                {
                    output = numbers;
                Console.WriteLine($"Result: { output * 2:f2}");
                }
            }
        }
    }
}
