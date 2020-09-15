using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            // Рекордът в секунди – реално число в интервала[0.00 … 100000.00]
            // Разстоянието в метри – реално число в интервала[0.00 … 100000.00]
            // Времето в секунди, за което плува разстояние от 1 м. - реално число в интервала[0.00 … 1000.00]
            double recordInSec = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeInSecForMeter = double.Parse(Console.ReadLine());

            // Calculation
            double swimmerSpeed = distanceInMeters * timeInSecForMeter;
            swimmerSpeed += Math.Floor(distanceInMeters / 15) * 12.5;
            
            // Output / Резултатът трябва да се форматира до втория знак след десетичната запетая.
            //•	Ако Иван е подобрил Световния рекорд отпечатваме:
            if ( swimmerSpeed < recordInSec)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {swimmerSpeed:f2} seconds.");
            }
            //	Ако НЕ е подобрил рекорда отпечатваме:
            else
            {
                Console.WriteLine($"No, he failed! He was {swimmerSpeed - recordInSec:f2} seconds slower.");
            }
            


        }
    }
}
