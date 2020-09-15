using System;

namespace _6._VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Брой дни – цяло число в интервала [1 … 5]
            //Брой часове за всеки един от дните - цяло число в интервала[1 … 24]
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double currSum = 0;
            double totalSum = 0;

            //четен ден и нечетен час - 2.50 лева.
            //нечетен ден и четен час - 1.25 лева
            //във всички останали случаи се заплаща 1 лев. 
            for (int d = 1; d <= days; d++)
            {
                currSum = 0;
                for (int h = 1; h <= hours; h++)
                {
                    if (d % 2 == 0 && h % 2 == 1)
                    {
                        currSum += 2.5;
                    }
                    else if (d % 2 == 1 && h % 2 == 0)
                    {
                        currSum += 1.25;
                    }
                    else
                    {
                        currSum += 1;
                    }
                    
                }
                totalSum += currSum;
                Console.WriteLine($"Day: {d} - {currSum:f2} leva");

            }

            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
