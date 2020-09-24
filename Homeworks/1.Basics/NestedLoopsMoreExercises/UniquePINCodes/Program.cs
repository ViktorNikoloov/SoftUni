using System;

namespace UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            for (int i = 1; i <= first; i++)
            {
                for (int a = 2; a <= second; a++)
                {
                    for (int s = 2; s <= third; s++)
                    {
                        if (i % 2 == 0 && s % 2 == 0 && (a == 2 || a % 2 == 1) && a != 9)
                        {
                            Console.WriteLine($"{i} {a} {s}");
                        }

                    }

                }

            }

        }
    }
}
