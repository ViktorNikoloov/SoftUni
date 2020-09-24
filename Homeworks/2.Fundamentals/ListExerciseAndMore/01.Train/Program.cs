using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            List<int> wagons = input;
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + int.Parse(command[0]) <= capacity)
                        {
                            wagons[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }

                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
