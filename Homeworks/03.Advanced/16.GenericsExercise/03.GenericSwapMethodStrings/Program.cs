using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                strings.Add(input);
            }

            int[] swapCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = swapCommand[0];
            int secondIndex = swapCommand[1];

            GenericList<string> genericList = new GenericList<string>(strings);
            genericList.SwapIndexes(firstIndex, secondIndex);

            Console.WriteLine(genericList.ToString());
         
            

        }
    }
}
