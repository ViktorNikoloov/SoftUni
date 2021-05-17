using System;
using System.Diagnostics;

namespace _01.PrimeNumberCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Synchronous code's Count and Time // PrintPrimeCount
            // 664580
            // 00:00:13.8449974
            
        }

        static void PrintPrimeCount()
        {
            Stopwatch sw = Stopwatch.StartNew();

            int n = 10_000_000;
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
            Console.WriteLine(sw.Elapsed);
        }
    }
}
