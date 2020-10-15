using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int> addFunc = add => add += 1;
            Func<int, int> multiplyFunc = multiply => multiply *= 2;
            Func<int, int> subtractFunc = subtract => subtract -= 1;
            Action<int[]> printFunc = numbers => Console.WriteLine(string.Join(" ", numbers));



            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(addFunc).ToArray();
                }
                else if(command == "multiply")
                {
                    numbers = numbers.Select(multiplyFunc).ToArray();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtractFunc).ToArray();
                }
                else if (command == "print")
                {
                    printFunc(numbers);

                }

                command = Console.ReadLine();
            }
        }
    }
}
