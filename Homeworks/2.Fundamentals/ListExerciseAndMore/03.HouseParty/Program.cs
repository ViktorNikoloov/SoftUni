using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandNumber = int.Parse(Console.ReadLine());
            //String[] demo = new string[commandNumber];
            //List<string> names = demo.ToList();

            for (int i = 0; i < commandNumber; i++)
            {
                List<string> currCommand = Console.ReadLine().Split().ToList();
                bool isItIn = false;

                if (currCommand.Count == 3)
                {
                    
                    for (int g = 0; g < names.Count - 1; g++)
                    {
                        if (names[g] == currCommand[0])
                        {
                            isItIn = true;
                        }

                    }
                    if (isItIn)
                    {
                        Console.WriteLine($"{currCommand[0]} is already in the list!");
                    }
                    else
                    {
                        names.Add(currCommand[0]);
                    }
                }
                else
                {
                    for (int g = 0; g < names.Count; g++)
                    {
                        if (names[g] == currCommand[0])
                        {
                            isItIn = true;
                        }
                        
                    }
                    if (isItIn)
                    {
                        names.Remove(currCommand[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{currCommand[0]} is not in the list!");

                    }
                }
            }
            names = names.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            for (int i = 0; i < names.Count; i++)
            {
               
                Console.WriteLine(names[i]);
            }
        }
    }
}
