using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>(input);

            for (int i = 0; i < input.Length; i++)
            {
                if (numbers.Peek() % 2 == 0)
                {
                    numbers.Enqueue(numbers.Dequeue());
                }
                else
                {
                    numbers.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", numbers));


        }
    }
}
