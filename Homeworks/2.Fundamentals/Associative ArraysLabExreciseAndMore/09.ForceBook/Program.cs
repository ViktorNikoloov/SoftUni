using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> members = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] command = input.Split(new string[] { " | ", " -> " },StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains(" | "))
                {
                    string forceSide = command[0];
                    string forceUser = command[1];

                    if (!members.ContainsKey(forceSide))
                    {
                        members[forceSide] = new List<string>();
                    }

                    if (!members.Values.Any(x => x.Contains(forceUser)))
                    {
                        members[forceSide].Add(forceUser);
                    }

                }
                else if (input.Contains(" -> "))
                {
                    string forceSide = command[1];
                    string forceUser = command[0];

                    if (members.Values.Any(x => x.Contains(forceUser)))
                    {
                        members.Values.Any(x => x.Remove(forceUser));
                    }

                    if (!members.ContainsKey(forceSide))
                    {
                        members[forceSide] = new List<string>();
                    }

                    members[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }

            }

            foreach (var users in members.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {

                Console.WriteLine($"Side: {users.Key}, Members: {users.Value.Count}");

                foreach (var user in users.Value.OrderBy(x => x))
                {
                    Console.WriteLine("! " + user);
                }
            }

        }
    }
}