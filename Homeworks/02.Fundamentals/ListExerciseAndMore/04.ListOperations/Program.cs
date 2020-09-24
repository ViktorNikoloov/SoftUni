using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<string> command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (command[0] != "End")
            {
                // •Add { number} – add number at the end.
                //•	Insert { number} { index} – insert number at given index.
                //•	Remove { index} – remove at index.
                //•	Shift left { count} – first number becomes last ‘count’ times.
                //•	Shift right { count} – last number becomes first ‘count’ times.
                //given index is outside of the bounds of the array. In that case print "Invalid index"
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    if (0 > int.Parse(command[2]) || numbers.Count <= int.Parse(command[2]))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    }

                }
                else if (command[0] == "Remove")
                {
                    if (0 > int.Parse(command[1]) || numbers.Count <= int.Parse(command[1]))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(command[1]));
                    }

                }
                else if (command[1] == "left")
                {
                    numbers = FromTheFirstToTheLastIndex(numbers, int.Parse(command[2]));
                }
                else if (command[1] == "right")
                {
                    numbers = FromThelastToTheFirstIndex(numbers, int.Parse(command[2]));
                }

                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        static List<int> FromTheFirstToTheLastIndex(List<int> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                // 1 2 3 4 5
                list.Insert(list.Count, list[0]);
                list.RemoveAt(0);
            }
            return list;
        }

        static List<int> FromThelastToTheFirstIndex(List<int> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                // 1 2 3 4 5
                list.Insert(0, list[list.Count - 1]);

                list.RemoveAt(list.Count - 1);
            }
            return list;
        }
    }
}
