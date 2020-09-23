using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (command[0] == 1)
                {

                    stack.Push(command[1]);

                }
                if (stack.Count > 0)
                {
                    if (command[0] == 2)
                    {
                        stack.Pop();
                    }
                    else if (command[0] == 3)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (command[0] == 4)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
