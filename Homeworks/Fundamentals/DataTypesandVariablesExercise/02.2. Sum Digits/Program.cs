using System;

namespace _02._2._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
