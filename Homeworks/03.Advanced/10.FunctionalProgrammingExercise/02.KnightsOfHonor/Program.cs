using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]>AppendingNameTitle= title =>
            {
                foreach (var name in title)
                {
                    Console.WriteLine("Sir " + name);

                }
            };

            AppendingNameTitle(Console.ReadLine().Split());
        }
    }
}
