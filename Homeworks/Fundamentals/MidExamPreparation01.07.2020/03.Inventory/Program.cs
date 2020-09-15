using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            
            List<string> command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (command[0] != "Craft!")
            {
                if (command[0] == "Collect")
                {
                    if (!journal.Contains(command[1]))
                    {
                        journal.Add(command[1]);
                    }


                }
                else if (command[0] == "Drop")
                {
                    if (journal.Contains(command[1]))
                    {
                        journal.Remove(command[1]);
                    }


                }
                else if (command[0] == "Combine Items")
                {
                    string temp = command[1];
                    List<string> combineItems = temp.Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (journal.Contains(combineItems[0]))
                    {
                        int oldItemIndex = journal.IndexOf(combineItems[0]);
                        journal.Insert(oldItemIndex + 1, combineItems[1]);
                    }


                }
                else if (command[0] == "Renew")
                {
                    if (journal.Contains(command[1]))
                    {
                        journal.Remove(command[1]);
                        journal.Add(command[1]);
                    }

                }

                command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
