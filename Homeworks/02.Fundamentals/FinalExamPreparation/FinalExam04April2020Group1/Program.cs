using System;
using System.Linq;

namespace FinalExam04April2020Group1
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string[] command = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            while (!command.Contains("Generate"))
            {
                if (command.Contains("Contains"))
                {
                    string substring = command[1];
                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (command.Contains("Flip") && command.Contains("Upper"))
                {
                    int startIndex = int.Parse(command[2]);
                    int endIndex = int.Parse(command[3]);

                    string upper = key.Substring(startIndex, (endIndex - startIndex)).ToUpper().ToString();
                    key = key.Remove(startIndex, (endIndex- startIndex));
                    key = key.Insert(startIndex, upper);

                    Console.WriteLine(key);
                }
                else if (command.Contains("Flip") && command.Contains("Lower"))
                {
                    int startIndex = int.Parse(command[2]);
                    int endIndex = (int.Parse(command[3]));

                    string lower = key.Substring(startIndex, (endIndex - startIndex)).ToLower().ToString();
                    key = key.Remove(startIndex, (endIndex - startIndex));
                    key = key.Insert(startIndex, lower);

                    Console.WriteLine(key);
                }
                else if (command.Contains("Slice"))
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    key = key.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(key);
                }

                command = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
