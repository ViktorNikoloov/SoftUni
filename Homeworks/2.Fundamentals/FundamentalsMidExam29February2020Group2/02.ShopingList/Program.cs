using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShopingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> command = Console.ReadLine().Split().ToList();
            while (command[0] != "Go")
            {
                if (command[0] == "Urgent")
                {
                    if (!list.Contains(command[1]))
                    {
                        list.Insert(0, command[1]);
                    }

                }
                else if (command[0] == "Unnecessary")
                {
                    if (list.Contains(command[1]))
                    {
                        list.Remove(command[1]);
                    }

                }
                else if (command[0] == "Correct")
                {
                    if (list.Contains(command[1]))
                    {
                        int index = list.IndexOf(command[1]);
                        list.RemoveAt(index);
                        list.Insert(index, command[2]);
                    }

                }
                else if (command[0] == "Rearrange")
                {
                    if (list.Contains(command[1]))
                    {
                        list.Add(command[1]);
                        list.Remove(command[1]);
                    }

                }


                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(String.Join(", ", list));
        }
    }
}
