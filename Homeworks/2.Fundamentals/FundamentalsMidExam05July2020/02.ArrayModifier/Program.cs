using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "swap") //{index1} {index2}” 
                {
                    int indexOne = int.Parse(command[1]);
                    int indexTwo = int.Parse(command[2]);
                    int temp = numbers[indexOne];

                    numbers[indexOne] = numbers[indexTwo];
                    numbers[indexTwo] = temp;

                }
                else if (command[0] == "multiply") //{index1} {index2}” 
                {
                    int indexOne = int.Parse(command[1]);
                    int indexTwo = int.Parse(command[2]);

                    numbers[indexOne] *= numbers[indexTwo];
                    
                }
                else if (command[0] == "decrease")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] -= 1;
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
