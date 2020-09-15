using System;
using System.Linq;

namespace _06.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < array.Length; i++) // 1 2 3 4 5 6
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int g = 0; g < i; g++)
                {
                    leftSum += array[g];
                }

                for (int k = i + 1; k < array.Length; k++)
                {
                    rightSum += array[k];
               
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                
            }

            Console.WriteLine("no");
        }
    }
}
