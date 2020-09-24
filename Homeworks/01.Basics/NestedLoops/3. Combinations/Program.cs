using System;

namespace _3._Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i <= number; i++)
            {
                for (int e = 0; e <= number; e++)
                {
                    for (int r = 0; r <= number; r++)
                    {

                        if ((i + e + r) == number)
                        {

                            count++;
                        }
                    }
                }
            }
            Console.WriteLine($"{count}");

        }
    }
}
