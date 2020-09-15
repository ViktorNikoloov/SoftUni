using System;

namespace DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 1; i <= input; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (numbers % 2 == 0)
                {
                    p1 += 1;
                }
                if (numbers % 3 == 0)
                {
                    p2 += 1;
                }
                if (numbers % 4 == 0)
                {
                    p3 += 1;
                }
            }

            Console.WriteLine($"{p1 / input * 100:f2}%");
            Console.WriteLine($"{p2 / input * 100:f2}%");
            Console.WriteLine($"{p3 / input * 100:f2}%");
        }
    }
}
