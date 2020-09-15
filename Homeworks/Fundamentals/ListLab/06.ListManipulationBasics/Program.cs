using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> currInput = input.Split().ToList();
                if (currInput[0] == "Add")
                {
                    numbers.Add(int.Parse(currInput[1]));
                }
                else if (currInput[0] == "Remove")
                {
                    numbers.Remove(int.Parse(currInput[1]));
                }
                else if (currInput[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(currInput[1]));
                }
                else if (currInput[0] == "Insert")
                {
                    numbers.Insert(int.Parse(currInput[2]), int.Parse(currInput[1]));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));

        }
    }
}
