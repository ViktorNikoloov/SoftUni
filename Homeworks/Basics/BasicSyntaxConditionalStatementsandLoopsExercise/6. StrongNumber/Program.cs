using System;

namespace _6._StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;
            int finalSum = 0;

            while (number != 0)
            {
                int symbol = number % 10;
                number /= 10;
                int sum = 1;

                for (int i = 1; i <= symbol; i++)
                {
                    sum *= i;
                }
                finalSum += sum;
                
            }
            if (input == finalSum)
            {
            Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
