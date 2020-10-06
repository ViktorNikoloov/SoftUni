using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(s => s[0] == s.ToUpper()[0]).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
