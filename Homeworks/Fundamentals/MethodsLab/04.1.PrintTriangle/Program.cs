using System;

namespace _04._1.PrintTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTriangle(number);
        }

        static void PrintNumberFromOne(int to)
        {
            for (int i = 1; i <= to; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static void PrintTriangle(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                PrintNumberFromOne(i);
            }

            for (int i = num - 1; i >= 1; i--)
            {
                PrintNumberFromOne(i);
            }
        }
    }
}
