using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            for (int i = 0; i < n; i++)
            {
                List<string> command = Console.ReadLine().Split().ToList();

                if (command.Count == 3)
                {
                    if (names.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                    else
                    {
                        names.Add(command[0]);
                    }

                }
                else
                {
                    if (names.Contains(command[0]))
                    {
                        names.Remove(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }

                }

            }

            names.ForEach(Console.WriteLine);
            
        }
    }
}
