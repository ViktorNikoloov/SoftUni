using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('|').Reverse().ToList();

            string numbers = string.Join(" ", input);
            List<string> output = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

           
            Console.WriteLine(string.Join(" ", output));



        }
    }
}
