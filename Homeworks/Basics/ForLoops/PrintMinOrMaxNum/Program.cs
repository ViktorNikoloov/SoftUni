using System;

namespace PrintMinOrMaxNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int maxnumber = int.MinValue;
            int minnumber = int.MaxValue;

            for (int i = 1; i <= numbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber > maxnumber)
                {
                    maxnumber = currentNumber;
                }

                if (currentNumber < minnumber)
                {
                    minnumber = currentNumber;
                }
            }

            Console.WriteLine($"Max number: {maxnumber}");
            Console.WriteLine($"Min number: {minnumber}");
        }
    }
}
