using System;

namespace _05._1_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int currNum = 0 ;

                while (number > 0)
                {
                    currNum += number % 10;
                    number /= 10;
                }
                bool isSpecial = currNum == 5 || currNum == 7 || currNum == 11;

                Console.WriteLine($"{i} -> {isSpecial}");
            }

        }
    }
}
