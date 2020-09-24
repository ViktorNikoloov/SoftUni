using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            Stack<string> stack = new Stack<string>(input);
            

            while(stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                int sum = 0;

                if (sign == "+")
                {
                    sum = firstNumber + secondNumber;
                }
                else
                {
                    sum = firstNumber - secondNumber;
                }
                string strSum = sum.ToString();

                stack.Push(strSum);


            }

            Console.WriteLine(stack.Pop());
        }
    }
}
