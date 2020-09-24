using System;

namespace _2.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int theBiggestDevNum = 0;
            bool isDivisible = false;
            //2,3,6,7,10
            if (num % 2 == 0 )
            {
                theBiggestDevNum = 2;
                isDivisible = true;
            }
            if (num % 3 == 0)
            {
                theBiggestDevNum = 3;
                isDivisible = true;
            }
            if (num % 6 == 0)
            {
                theBiggestDevNum = 6;
                isDivisible = true;
            }
            if (num % 7 == 0)
            {
                theBiggestDevNum = 7;
                isDivisible = true;
            }
            if (num % 10 == 0)
            {
                theBiggestDevNum = 10;
                isDivisible = true;
            }
            if (isDivisible == false)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
            Console.WriteLine($"The number is divisible by {theBiggestDevNum}");
            }
        }
    }
}
