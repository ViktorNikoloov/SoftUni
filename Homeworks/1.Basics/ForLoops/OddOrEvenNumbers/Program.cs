using System;

namespace OddOrEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int evenNum = 0;
            int oddNum = 0;

            for (int i = 1; i <= num; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenNum += currNum;
                }
                else
                {
                    oddNum += currNum;
                }
            }

            if (evenNum == oddNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenNum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(1.0 * oddNum - evenNum)}");
            }
        }
    }
}
