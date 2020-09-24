using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3).ToList();

            //for (int i = 0; i < 3; i++)
            //{
            //    if (i < 3 && i < numbers.Count)
            //    {
            //        Console.Write(numbers[i] + " ");

            //    }

            //}

            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }



        }
    }
}
