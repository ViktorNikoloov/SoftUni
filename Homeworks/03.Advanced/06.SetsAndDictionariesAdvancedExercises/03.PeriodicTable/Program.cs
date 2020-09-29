using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueElements = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] element = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int g = 0; g < element.Length; g++)
                {
                uniqueElements.Add(element[g]);
                }
            }

            var orderedElements =  uniqueElements.OrderBy(x => x).ToHashSet();

            foreach (var element in orderedElements)
            {
                Console.Write(element + " ");
            }
        }
    }
}
