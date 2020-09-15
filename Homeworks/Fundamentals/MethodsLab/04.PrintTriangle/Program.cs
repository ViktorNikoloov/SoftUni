using System;

namespace _04.PrintTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberForPrinting = int.Parse(Console.ReadLine());

            PrintTriangleOfNumbers(NumberForPrinting);
        }

        static void PrintTriangleOfNumbers(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                for (int g = 1; g <= i; g++)
                {
                    Console.Write(g + " ");
                }
                Console.WriteLine();
            }

            for (int i = 1; i <= number - 1; i++)
            {
                for (int g = 1; g <= number - i; g++)
                {
                    Console.Write(g + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
