using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(numbers);
            
            string[] commands = Console.ReadLine().ToLower().Split().ToArray();
            while (commands[0] != "end")
            {
                if (commands[0] =="add")
                {
                    int firstNum = int.Parse(commands[1]);
                    int secondNum = int.Parse(commands[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);

                }
                else if (commands[0] == "remove")
                {
                    int numbersToRemove = int.Parse(commands[1]);

                    if (numbersToRemove <= stack.Count)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                commands = Console.ReadLine().ToLower().Split().ToArray();

            }

            int sumOfTheStack = 0;

            //int lengthOfTheStack = stack.Count;
            //for (int i = 0; i < lengthOfTheStack; i++)
            //{
            //    sumOfTheStack += stack.Pop();
            //}

            while (stack.Count > 0)
            {
                sumOfTheStack += stack.Pop();
            }

            Console.WriteLine($"Sum: {sumOfTheStack}");
        }
    }
}
