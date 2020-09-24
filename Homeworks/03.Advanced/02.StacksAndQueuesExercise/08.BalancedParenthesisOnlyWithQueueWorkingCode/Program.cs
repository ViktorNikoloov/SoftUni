using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesisOnlyWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Queue<char> brackets = new Queue<char>(input);

            bool isBalanced = false;
            int counter = 0;

            while ((brackets.Count % 2 == 0) && (brackets.Count != 0))
            {
                char firstBracket = brackets.Dequeue();
                char secondBracket = brackets.Peek();

                if (!((firstBracket == '(' && secondBracket == ')') || (firstBracket == '[' && secondBracket == ']') || (firstBracket == '{' && secondBracket == '}')))
                {
                    if (counter == brackets.Count)
                    {
                        break;
                    }

                    brackets.Enqueue(firstBracket);
                    isBalanced = false;
                    counter++;

                }
                else
                {
                    brackets.Dequeue();
                    isBalanced = true;
                    counter = 0;
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
