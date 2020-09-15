using System;

namespace BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            //input 
            // Наследените пари – реално число в интервала[1.00... 1 000 000.00]
            //Годината, до която трябва да живее(включително) – цяло число в интервала[1801... 1900]
            double money = double.Parse(Console.ReadLine());
            int yearToLive = int.Parse(Console.ReadLine());

            int birthdayYears = 18;
            int evenYearsSum = 0;
            int oddYearsSum = 0;

            //Той решава да се върне до 1800г
            //за всяка четна (0,2,4) година ще харчи 12 000 лева. За всяка нечетна (1,3,5)
            //ще харчи 12 000 + 50 * [годините, които е навършил през дадената година].

            for (int i = 1800; i <= yearToLive; i++)
            {
                if (i % 2 == 0)
                {
                    evenYearsSum += 12000;
                }
                else
                {
                    oddYearsSum += (12000 + 50 * birthdayYears);
                }

                birthdayYears += 1;
            }
            int totalSum = oddYearsSum + evenYearsSum;
            if (money >= totalSum)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {money - totalSum:f2} dollars left.");
            }
            else
            {

                Console.WriteLine($"He will need {totalSum - money:f2} dollars to survive.");
            }

        }
    }
}
