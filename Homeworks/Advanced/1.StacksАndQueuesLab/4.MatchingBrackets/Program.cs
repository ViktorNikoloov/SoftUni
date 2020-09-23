using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var chars = input.ToCharArray();
            var brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currChar = chars[i];
                if (currChar == '(')
                {
                    brackets.Push(i);
                }
                else if (currChar == ')')
                {
                    var startIndex = brackets.Pop();
                    var endIndex = i;

                    Console.WriteLine(input.Substring(startIndex, endIndex - startIndex + 1));
                }
            }


        }
    }
}
