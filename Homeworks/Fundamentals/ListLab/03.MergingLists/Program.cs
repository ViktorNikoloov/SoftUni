using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondInput = Console.ReadLine().Split().Select(int.Parse).ToList();

            MergedIntegers(firstInput, secondInput);
        }

        static void MergedIntegers(List<int> firstInput, List<int> secondInput)
        {
            List<int> result = new List<int>();

            int maxCount = Math.Max(firstInput.Count, secondInput.Count);

            for (int i = 0; i < maxCount; i++)
            {
                if (i < firstInput.Count)
                {
                    result.Add(firstInput[i]);
                }
                if (i < secondInput.Count)
                {
                    result.Add(secondInput[i]);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
        
    }
}
