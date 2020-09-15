using System;

namespace Histogram_проценти_
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 1; i <= input; i++)
            {

                int numbers = int.Parse(Console.ReadLine());

                if (numbers < 200)
                {
                    p1 += 1;
                }
                else if (numbers < 400)
                {
                    p2 += 1;
                }
                else if (numbers < 600)
                {
                    p3 += 1;
                }
                else if (numbers < 800)
                {
                    p4 += 1;
                }
                else if (numbers >= 800)
                {
                    p5 += 1;
                }
            }
            
            Console.WriteLine($"{(1.00 * p1 / input) * 100:f2}%");
            Console.WriteLine($"{(1.00 * p2 / input) * 100:f2}%");
            Console.WriteLine($"{(1.00 * p3 / input) * 100:f2}%");
            Console.WriteLine($"{(1.00 * p4 / input) * 100:f2}%");
            Console.WriteLine($"{(1.00 * p5 / input) * 100:f2}%");
        }
    }
}
