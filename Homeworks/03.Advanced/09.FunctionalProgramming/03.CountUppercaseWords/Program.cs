using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(s => s[0] == s.ToUpper()[0]).ToArray();
            //foreach (var word in input)
            //{
            //    Console.WriteLine(word);
            //}

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(s => s[0] == s.ToUpper()[0]).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
