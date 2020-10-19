using System;
using System.Collections.Generic;

namespace _03.GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }

            string[] swapCommand = Console.ReadLine().Split();
            int firstIndex = int.Parse(swapCommand[0]);
            int secondIndex = int.Parse(swapCommand[1]);

            GenericList<string> genericList = new GenericList<string>(list);
            genericList.SwapIndexes(firstIndex, secondIndex);

            Console.WriteLine(genericList.ToString());
         
            

        }
    }
}
