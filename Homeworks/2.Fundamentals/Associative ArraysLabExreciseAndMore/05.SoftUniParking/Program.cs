using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registered = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                string name = commands[1];
                

                if (command == "register")
                {
                    string plateNumber = commands[2];

                    if (registered.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
                    }
                    else
                    {
                        registered.Add(name, plateNumber);
                        Console.WriteLine($"{name} registered {plateNumber} successfully");
                    }
                }
                else
                {
                    if (!registered.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        registered.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }

            }

            foreach (var user in registered)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
