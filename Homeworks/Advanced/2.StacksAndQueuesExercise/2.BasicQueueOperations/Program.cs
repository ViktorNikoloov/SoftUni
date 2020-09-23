using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();// N-elements to push, S-the number of elements to pop, X-should look for
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int toSearch = values[2];

            Queue<int> numbers = new Queue<int>(input);


            for (int i = 0; i < values[1]; i++)
            {
                numbers.Dequeue();

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
