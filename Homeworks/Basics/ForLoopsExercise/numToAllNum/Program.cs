using System;

namespace numToAllNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNum = int.MinValue;
            for (int i = 0; i < input; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                sum += currNum;

                if (currNum > maxNum)
                {
                    maxNum = currNum;

                }
                
            }

            sum -= maxNum;

            if (maxNum == sum)
            {

                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = { maxNum}");
            }
            else
            {

                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNum - sum)}");
            }
            
        }
    }
}
