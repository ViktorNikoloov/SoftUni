using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            bool ifChanged = false;
            while (command != "end")
            {
                List<string> input = command.Split().ToList();
                if (input[0] == "Add")
                {
                    numbers.Add(int.Parse(input[1]));
                    ifChanged = true;
                }
                else if (input[0] == "Remove")
                {
                    numbers.Remove(int.Parse(input[1]));
                    ifChanged = true;
                }
                else if (input[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(input[1]));
                    ifChanged = true;
                }
                else if (input[0] == "Insert")
                {
                    numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                    ifChanged = true;
                }
                else if (input[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(input[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (input[0] == "PrintEven")
                {
                    PrintEven(numbers);
                }
                else if (input[0] == "PrintOdd")
                {
                    PrintOdd(numbers);
                }
                else if (input[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (input[0] == "Filter")
                {
                    Filter(numbers, input[1], int.Parse(input[2]));
                }

                command = Console.ReadLine();
            }
            if (ifChanged)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }

        }

        static void PrintEven(List<int> input)
        {
            List<int> evenNumbers = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 0)
                {
                    evenNumbers.Add(input[i]);
                }
            }

            Console.WriteLine(String.Join(" ", evenNumbers));
        }

        static void PrintOdd(List<int> input)
        {
            List<int> evenNumbers = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 != 0)
                {
                    evenNumbers.Add(input[i]);
                }
            }

            Console.WriteLine(String.Join(" ", evenNumbers));
        }

        static void Filter(List<int> input, string condition, int number)
        {
            List<int> output = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (condition == "<")
                {
                    if (input[i] < number)
                    {
                        output.Add(input[i]);
                    }

                }
                else if (condition == "<=")
                {
                    if (input[i] <= number)
                    {
                        output.Add(input[i]);
                    }
                }
                else if (condition == ">")
                {
                    if (input[i] > number)
                    {
                        output.Add(input[i]);
                    }
                }
                else if (condition == ">=")
                {
                    if (input[i] >= number)
                    {
                        output.Add(input[i]);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", output));
        }
    }
}
