using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<string> command = Console.ReadLine().Split().ToList();
            while (command[0] != "End")
            {
                //47 55 85 78 99 20
                if (command[0] == "Shoot")
                {
                    // Shoot {index} {power}
                    int index = int.Parse(command[1]);
                    int power = int.Parse(command[2]);
                    if (0 <= index && index < targets.Count)
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }

                }
                else if (command[0] == "Add")
                {
                    // Add {index} {value}
                    int index = int.Parse(command[1]);
                    int value = int.Parse(command[2]);

                    if (0 <= index && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (command[0] == "Strike")
                {
                    //•	Strike {index} {radius}
                    int index = int.Parse(command[1]);
                    int radius = int.Parse(command[2]);

                    if (index < 0 || (index - radius) < 0 || (index + radius) >= targets.Count - 1 || radius >= targets.Count - 1)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        //1 2 3 4 5 6 7 - 3,2
                        //  -   3   -
                        targets.RemoveRange(index - radius, radius * 2 + 1);
                    }
                }
               
                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(String.Join("|", targets));
        }
    }
}
