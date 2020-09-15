using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            int count = 0;
            string lastResource = string.Empty;


            string command = Console.ReadLine();
            while (command != "stop")
            {
                count++;

                if (count % 2 !=0)
                {
                    if (!resources.ContainsKey(command))
                    {
                        resources.Add(command, 0);
                        
                    }
                    
                    lastResource = command;
                }
                else
                {
                    
                    resources[lastResource] += int.Parse(command);
                }
                

                command = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
