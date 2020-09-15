using System;
using System.Collections.Generic;
using System.Data;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> users = new SortedDictionary<string, List<string>>();

            string[] command = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {
                string company = command[0];
                string id = command[1];

                if (!users.ContainsKey(company))
                {
                    users.Add(company, new List<string>());
                    users[company].Add(id);
                }
                else
                {
                    if (!users[company].Contains(id))
                    {
                        users[company].Add(id);
                    }
                }

                command = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var pair in users)
            {
                Console.WriteLine(pair.Key);

                foreach (var id in pair.Value)
                {
                    Console.WriteLine("-- " + id);
                }

            }
        }
    }
}
