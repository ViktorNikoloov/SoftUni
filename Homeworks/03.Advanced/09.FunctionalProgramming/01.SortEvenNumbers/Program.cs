using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arrOfNumbers = Console.ReadLine()
            //.Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //.Select(x => int.Parse(x))
            //.Where(x => x % 2 == 0)
            //.OrderBy(x => x).ToArray();
            //Console.WriteLine(string.Join(", ", arrOfNumbers));


            Console.
                ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
