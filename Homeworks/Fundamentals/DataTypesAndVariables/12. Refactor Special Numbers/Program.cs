using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int currNum = i;

                while (currNum > 0)
                {
                    sum += currNum % 10;
                    currNum /= 10;
                }
                bool isItSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{i} -> {isItSpecial}");
                
            }

        }
    }
}
