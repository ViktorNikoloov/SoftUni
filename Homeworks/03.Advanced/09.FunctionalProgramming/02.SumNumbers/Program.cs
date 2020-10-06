using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseNumber)
                .ToArray();

            //Func<int[], int> count = CountOfArrayNumbers;
            //Func<int[], int> sum = SumOfArrayNumbers;

            PrintResult(numbers, CountOfArrayNumbers, SumOfArrayNumbers);
        }

        static void PrintResult(int[] arr,
            Func<int[], int> count,
            Func<int[], int> sum)
        {
            
            Console.WriteLine(count(arr));
            Console.WriteLine(sum(arr));
        }

        static int CountOfArrayNumbers(int[] arr)
        {
            return arr.Length;
        }

        static int SumOfArrayNumbers(int[] arr)
        {
            return arr.Sum();
        }

        static int ParseNumber(string number)
        {
            return int.Parse(number);
        }
    }
}
