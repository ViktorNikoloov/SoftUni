using System;

namespace RightAndLeftSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < count; i++)
            {
                int leftNum = int.Parse(Console.ReadLine());
                leftSum +=leftNum;
            }

            for (int i = 0; i < count; i++)
            {
                int rightNum = int.Parse(Console.ReadLine());
                rightSum +=rightNum;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {rightSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(rightSum - leftSum)}");
            }

        }
    }
}
