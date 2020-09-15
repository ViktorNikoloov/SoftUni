using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;

            for (int i = 0; i < num; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (numbers > maxNum)
                {
                    maxNum = numbers;
                }
            }

            Console.WriteLine(maxNum);
        }
    }
}
