using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] arrOfDoubleNumbers = Console.ReadLine()
            //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => double.Parse(x))
            //    .Select(x=> x + x *0.2)
            //    .ToArray();

            //foreach (var number in arrOfDoubleNumbers)
            //{
            //    Console.WriteLine($"{number:f2}");
            //}

            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .Select(x => x + x * 0.2)
                .ToList().ForEach(x => Console.WriteLine($"{x:f2}"));

            double[] arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(x => x + x * 0.2).ToArray();
            Console.WriteLine(string.Join(" ", arr));
        }


    }
}
