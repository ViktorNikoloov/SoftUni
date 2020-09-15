using System;
using System.Linq;

namespace FinalExamRetake13DecemberTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            string[] command = Console.ReadLine().Split();
            while (!command.Contains("Azeroth"))
            {
                if (!(command.Contains("GladiatorStance") || command.Contains("DefensiveStance") || command.Contains("Dispel") || command.Contains("Change") || command.Contains("Remove")))
                {
                    Console.WriteLine("Command doesn't exist!");
                }
                if (command.Contains("GladiatorStance"))
                {
                    skill = skill.ToUpper().ToString();
                    Console.WriteLine(skill);
                }
                else if (command.Contains("DefensiveStance"))
                {
                    skill = skill.ToLower().ToString();
                    Console.WriteLine(skill);

                }
                else if (command.Contains("Dispel"))
                {
                    int index = int.Parse(command[1]);
                    string letter = command[2];

                    if (0 <= index && index <= skill.Length - 1)
                    {
                        skill = skill.Remove(index, 1);
                        skill = skill.Insert(index, letter);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }

                }
                else if (command.Contains("Change")) //Target Change {substring} {second substring}"
                {
                    string oldSubstring = command[2];
                    string newSubstring = command[3];

                    skill = skill.Replace(oldSubstring, newSubstring);
                    Console.WriteLine(skill);

                }
                else if (command.Contains("Remove"))
                {
                    string substring = command[2];
                    int index = skill.IndexOf(substring);

                    skill = skill.Remove(index, substring.Length);
                    Console.WriteLine(skill);
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}
