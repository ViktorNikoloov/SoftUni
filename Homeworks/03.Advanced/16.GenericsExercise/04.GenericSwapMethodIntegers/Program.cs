using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                numbers.Add(input);
            }

            BoxOfT<int> box = new BoxOfT<int>(numbers);
            int[] swapCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = swapCommand[0];
            int SecondIndex = swapCommand[1];

            box.SwapIndexes(firstIndex, SecondIndex);

            Console.WriteLine(box.ToString());
        }
    }
}
