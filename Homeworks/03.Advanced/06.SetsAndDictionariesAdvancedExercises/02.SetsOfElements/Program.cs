using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> uniqueSet = new HashSet<int>();

            int[] length = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < length[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < length[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    uniqueSet.Add(number);
                }
            }
            
            foreach (var number in uniqueSet)
            {
                Console.Write(number + " ");
            }

        }
    }
}
