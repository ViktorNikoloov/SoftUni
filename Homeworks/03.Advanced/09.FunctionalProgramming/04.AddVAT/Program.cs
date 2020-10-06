using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrOfDoubleNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .Select(x=> x + x *0.2)
                .ToArray();

            foreach (var number in arrOfDoubleNumbers)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}
