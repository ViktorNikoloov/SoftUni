using System;
using System.Linq;

namespace _09.CaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "Clone them")
            {
                int[] currDna = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                input = Console.ReadLine();
            }
            Console.WriteLine("Hello");
           // Console.WriteLine(String.Join(" ", dna));
            

            

        }
    }
}
