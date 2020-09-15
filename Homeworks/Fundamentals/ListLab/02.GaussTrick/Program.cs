using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbers = new List<int>(input);

            for (int i = 0; i < input.Count / 2; i++)
            {
                numbers[i] = input[i] + input[input.Count - i - 1];
                numbers.RemoveAt(numbers.Count - 1);
                
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
