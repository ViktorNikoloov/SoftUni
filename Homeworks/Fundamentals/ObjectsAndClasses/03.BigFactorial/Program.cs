using System;
using System.Numerics;

namespace _03.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(BigFactorial.Calculate(number));
        }
    }

    class BigFactorial
    {
        public static BigInteger Calculate(BigInteger number)
        {
            BigInteger bigInteger = 1;

            for (int i = 1; i <= number; i++)
            {
                bigInteger *= i;
            }

            return bigInteger;
        }
    }
}
