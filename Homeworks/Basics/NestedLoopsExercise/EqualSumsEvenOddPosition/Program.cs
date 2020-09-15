using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                int currNum = i;
                int oddSum = 0;
                int evenSum = 0;
                int count = 0;

                while (currNum != 0)
                {
                    int digit = currNum % 10;
                    if (count % 2 == 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }
                    currNum = currNum / 10;
                    count++;
                }

                if (oddSum == evenSum)
                {
                    Console.WriteLine(i + " ");
                }
            }
        }
    }
}
