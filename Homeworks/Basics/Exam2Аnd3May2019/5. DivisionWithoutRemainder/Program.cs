using System;

namespace _5._DivisionWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int two = 0;
            int three = 0;
            int four = 0;

            for (int i = 1; i <= input; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (numbers % 2 == 0)
                {
                    two++;
                }
                if (numbers % 3 == 0)
                {
                    three++;
                }
                if (numbers % 4 == 0)
                {
                    four++;
                }
            }

            Console.WriteLine($"{(double)two / input * 100:f2}%");
            Console.WriteLine($"{(double)three / input * 100:f2}%");
            Console.WriteLine($"{(double)four / input * 100:f2}%");

        }
    }
}
