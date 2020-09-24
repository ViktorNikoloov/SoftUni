using System;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string weather = Console.ReadLine();
            string outside = "sunny";
            if (weather == outside)
            {
                Console.WriteLine("It's warm outside!");
            }

            else
            {
                Console.WriteLine("It's cold outside!");
            }

        }
    }
}
