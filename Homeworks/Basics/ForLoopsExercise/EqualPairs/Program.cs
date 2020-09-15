using System;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            int lastSum = 0;
            int diff = 0;

            for (int i = 0; i < numberOfNumbers; i++)
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());

                int sum = firstNum + secondNum;

                if (i > 0)
                {
                    diff = Math.Abs(lastSum - sum);
                }
                lastSum = sum;
            }

            if (diff == 0)
            {
                Console.WriteLine($"Yes, value={lastSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
