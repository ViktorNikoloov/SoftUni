using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();// N-elements to push, S-the number of elements to pop, X-should look for
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(input);

            int toPop = values[1];
            int toSearch = values[2];

            for (int i = 0; i < toPop; i++)
            {
                numbers.Pop();

            }

            if (values.Contains(toSearch))
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else if (numbers.Contains(toSearch))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }
    }
}

