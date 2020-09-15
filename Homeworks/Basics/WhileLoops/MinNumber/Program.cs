using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int MinNumber = int.MaxValue;

            for (int i = 0; i < num; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (numbers < MinNumber)
                {
                    MinNumber = numbers;
                }

            }

            Console.WriteLine(MinNumber);
        }
    }
}
