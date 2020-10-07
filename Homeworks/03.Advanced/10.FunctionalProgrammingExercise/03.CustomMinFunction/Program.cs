using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<int[], int> TheSmallestNumber = array =>
            //{

            //    return array.Min();
            //};

            Func<int[], int> TheSmallestNumber = MinNumberInArray;

            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(TheSmallestNumber(input));
        }

        static int MinNumberInArray(int[] array)
        {
            return array.Min();
        }
    }
}
