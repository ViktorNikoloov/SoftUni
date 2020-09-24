using System;
using System.Collections.Generic;
using System.Linq;
namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Queue<char> leftSide = new Queue<char>();
            Stack<char> rightSide = new Stack<char>();
            bool isBalanced = true;

            for (int i = 0; i < input.Length / 2; i++)
            {
                char currScope = input[i];
                leftSide.Enqueue(currScope);
            }

            for (int i = input.Length / 2; i < input.Length; i++)
            {
                char currScope = input[i];
                rightSide.Push(currScope);
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                char currLeftScope = leftSide.Dequeue();
                char currRightScope = rightSide.Pop();

                if (!((leftSide.Count == rightSide.Count) && 
                    (currLeftScope == '(' && currRightScope == ')') ||
                    (currLeftScope == ')' && currRightScope == '(') ||
                    (currLeftScope == '[' && currRightScope == ']') ||
                    (currLeftScope == ']' && currRightScope == '[') ||
                    (currLeftScope == '{' && currRightScope == '}') ||
                    (currLeftScope == '}' && currRightScope == '{')))
                {
                    isBalanced = false;
                    break;
                }

            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

