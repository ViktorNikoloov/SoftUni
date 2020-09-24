using System;
using System.Linq;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();

            string[] command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            while (!(command.Contains("Travel")))
            {
                if (command.Contains("Add Stop")) // Add Stop:{index}:{string} 
                {
                    int index = int.Parse(command[1]);
                    string str = command[2];

                    if (0 <= index && index <= destinations.Length - 1)
                    {
                        destinations = destinations.Insert(index, str);
                    }

                    Console.WriteLine(destinations);
                }
                else if (command.Contains("Remove Stop")) // Remove Stop:{start_index}:{end_index} 
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if ((0 <= startIndex && startIndex <= destinations.Length - 1) && (0 <= endIndex && endIndex <= destinations.Length - 1))
                    {
                        destinations = destinations.Remove(startIndex, endIndex - startIndex + 1);
                    }

                    Console.WriteLine(destinations);
                }
                else if (command.Contains("Switch")) // Switch:{old_string}:{new_string} 
                {
                    string oldStr = command[1];
                    string newStr = command[2];

                    if (destinations.Contains(oldStr))
                    {
                        destinations = destinations.Replace(oldStr, newStr);
                    }

                    Console.WriteLine(destinations);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {destinations}");

        }
    }
}
