using System;

namespace ScholarShip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            // Доход в лева -реално число в интервала[0.00..6000.00]
            // Среден успех - реално число в интервала[2.00...6.00]
            // Минимална работна заплата -реално число в интервала[0.00..1000.00]
            double profit = double.Parse(Console.ReadLine());
            double middleGrade = double.Parse(Console.ReadLine());
            double minSelary = double.Parse(Console.ReadLine());

            // Calculation
            //Размер на социалната стипендия - 35 % от минималната работна заплата
            double socialShip = minSelary * 0.35;

            //Размер на стипендията за отличен успех - успехът на ученика, умножен по коефициент 25.
            double excellentGrade = middleGrade * 25;

            // Ако ученикът няма право да получава стипендия, се извежда:
            
            //Изискване за социална стипендия - доход на член от семейството по-малък 
            //от минималната работна заплата и успех над 4.5.
            if (profit < minSelary)
            {
                if (middleGrade > 4.5)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialShip)} BGN");
                }
            }
            //Изискване за стипендия за отличен успех - успех над 5.5, включително.
            else if (middleGrade >= 5.5)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentGrade)} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }


        }
    }
}
