using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExam07DecemberGroup1Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            string[] command = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);
            while (!(command.Contains("Statistics")))
            {

                if (command.Contains("Add"))
                {
                    string name = command[1];

                    if (!(users.Keys.Contains(name)))
                    {
                        users.Add(name, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already registered");
                    }
                }
                else if (command.Contains("Send"))
                {
                    string name = command[1];
                    string email = command[2];

                    users[name].Add(email);
                }
                else if (command.Contains("Delete"))
                {
                    string name = command[1];

                    if (users.Keys.Contains(name))
                    {
                        users.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} not found!");
                    }
                }

                command = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);

            }

            Console.WriteLine("Users count: " + users.Keys.Count);

            foreach (var user in users.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var email in user.Value)
                {
                    Console.WriteLine(" - " + email);
                }

            }
        }
    }
}
