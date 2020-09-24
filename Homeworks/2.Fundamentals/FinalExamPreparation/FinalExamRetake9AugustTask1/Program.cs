using System;
using System.Linq;

namespace FinalExamRetake9AugustTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string[] command = Console.ReadLine().Split();
            while (!command.Contains("Sign"))
            {
                if (command.Contains("lower"))
                {
                    username = username.ToLower().ToString();
                    Console.WriteLine(username);
                }
                else if (command.Contains("upper"))
                {
                    username = username.ToUpper().ToString();
                    Console.WriteLine(username);
                }
                else if (command.Contains("Reverse"))
                {
                    int startIndex = int.Parse(command[1]), endIndex = int.Parse(command[2]);

                    if (0 <= startIndex && endIndex <= username.Length - 1)
                    {
                        string substring = username.Substring(startIndex, endIndex - startIndex + 1);
                        string reversed = new string(substring.Reverse().ToArray());
                        Console.WriteLine(reversed);
                    }
                }
                else if (command.Contains("Cut"))
                {
                    string cut = command[1];
                    if (username.Contains(cut))
                    {
                        int Index = username.IndexOf(cut);
                        username = username.Remove(Index, cut.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {cut}.");
                    }
                }
                else if (command.Contains("Replace"))
                {
                    char oldChar = char.Parse(command[1]);
                    username = username.Replace(oldChar, '*');
                    Console.WriteLine(username);
                }
                else if (command.Contains("Check"))
                {
                    char contains = char.Parse(command[1]);
                    if (username.Contains(contains))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {contains}.");
                    }

                }

                command = Console.ReadLine().Split();
            }
        }
    }
}
