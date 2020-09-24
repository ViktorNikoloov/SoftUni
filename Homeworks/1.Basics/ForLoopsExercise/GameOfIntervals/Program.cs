using System;

namespace GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред - колко хода ще има по време на играта – цяло число в интервала [1...100]
            int duration = int.Parse(Console.ReadLine());
            double resultPoints = 0;

            int invalid = 0; // if the number is bigger than 50 or it is negative !
            int belowNine = 0; //От 0 до 9
            int tenToNineteen = 0; //От 10 до 19
            int twentyToTwentynine = 0; //От 20 до 29
            int thirtyToThirtynine = 0; //От 30 до 39
            int fortyToFifty = 0; //От 40 до 50 



            //За всеки ход – числата, които се проверяват в кой интервал са – цели числа в интервала[-100...100]
            for (int i = 0; i < duration; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (0 <= numbers && numbers <= 9) //20 % от числото
                {
                    belowNine += 1;
                    resultPoints += numbers * 0.2;
                }
                else if (10 <= numbers && numbers <= 19) //30 % от числото
                {
                    tenToNineteen += 1;
                    resultPoints += numbers * 0.3;
                }
                else if (20 <= numbers && numbers <= 29) //40 % от числото
                {
                    twentyToTwentynine += 1;
                    resultPoints += numbers * 0.4;
                }
                else if (30 <= numbers && numbers <= 39) //50 точки
                {
                    thirtyToThirtynine += 1;
                    resultPoints += 50;
                }
                else if (40 <= numbers && numbers <= 50) //100 точки
                {
                    fortyToFifty += 1;
                    resultPoints += 100;
                }

                if (-1 >= numbers || numbers > 50) //резултата се дели на 2
                {
                    invalid += 1;
                    resultPoints /= 2;
                }
            }

            Console.WriteLine($"{resultPoints:f2}");
            Console.WriteLine($"From 0 to 9: {1.0 * belowNine / duration * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {1.0 * tenToNineteen / duration * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {1.0 * twentyToTwentynine / duration * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {1.0 * thirtyToThirtynine / duration * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {1.0 * fortyToFifty / duration * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {1.0 * invalid / duration * 100:f2}%");

        }
    }
}
