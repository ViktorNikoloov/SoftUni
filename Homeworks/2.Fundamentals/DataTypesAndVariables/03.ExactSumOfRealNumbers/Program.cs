using System;

namespace _03.ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal dollars = pounds * (decimal)1.31;


            Console.WriteLine($"{dollars:f3}");
        }
    }
}
