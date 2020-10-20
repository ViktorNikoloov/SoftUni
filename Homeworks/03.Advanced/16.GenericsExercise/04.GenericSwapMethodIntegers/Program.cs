using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            BoxOfT<int> box = new BoxOfT<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Values.Add(input);
            }

            int[] swapCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = swapCommand[0];
            int SecondIndex = swapCommand[1];

            box.Swap(firstIndex, SecondIndex);

            Console.WriteLine(box.ToString());
        }
    }
}
