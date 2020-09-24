using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<string> command = Console.ReadLine().Split().ToList();
            while (command[0] != "end")
            {
                if (command[0] == "Insert")
                {
                    input.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                if (command[0] == "Delete")
                {
                    //for (int i = 0; i < input.Count; i++)
                    //{
                    //    if (input[i] == int.Parse(command[1]))
                    //    {
                    //        input.RemoveAt(i);
                    //        i--;
                    //    }
                    //}

                    input.RemoveAll(x => x == int.Parse(command[1]));
                }

                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(String.Join(" ", input));
        }
    }
}
