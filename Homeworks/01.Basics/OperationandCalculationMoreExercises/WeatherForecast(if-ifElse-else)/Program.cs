using System;

namespace WeatherForecast_if_ifElse_else_
{
    class Program
    {
        static void Main(string[] args)
        {
            // 26.00 - 35.00 Hot
            // 20.1 - 25.9 Warm
            // 15.00 - 20.00 Mild
            // 12.00 - 14.9  Cool
            // 5.00 - 11.9 Cold

            double degrees = double.Parse(Console.ReadLine());
            if (degrees < 5)
            {
                Console.WriteLine("unknown");
            }
            else if (degrees <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else if (degrees <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (degrees <= 20.00)
            {
                Console.WriteLine("Mild");
            }
            else if (degrees <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (degrees <= 35.00)
            {
                Console.WriteLine("Hot");
            }
            else
            {
                Console.WriteLine("unknown");
            }


        }
    }
}
