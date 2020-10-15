using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string evenOrOdd = Console.ReadLine();

            List<int> numbers = new List<int>();

            int startNum = input[0];
            int endNum = input[1];
            for (int i = startNum; i <= endNum; i++)
            {
                numbers.Add(i);
            }



            Predicate<int> isEven = num => num % 2 == 0;

            Action<List<int>> printNumbers = num => Console.WriteLine(string.Join(" ", num));
            List<int> result = new List<int>()

            if (evenOrOdd == "odd")
            {
                //numbers.RemoveAll(x => isEven(x));
                result = numbers.FindAll(x => !isEven(x));

            }
            else
            {
                //numbers.RemoveAll(x => !isEven(x));
                result = numbers.FindAll(x => isEven(x));

            }

            //printNumbers(numbers);
            printNumbers(result);

        }

    }
}
