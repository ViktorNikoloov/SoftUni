using System;

namespace SpeedInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            // read speed, integer number
            double speed = double.Parse(Console.ReadLine());

            //if speed <=10 - slow
            if (speed <= 10)
            {
                Console.WriteLine("slow");
            }

            //if speed <=50 average
            else if (speed <= 50)
            {
                Console.WriteLine("average");
            }
            //if speed <=150 fast
            else if (speed <= 150)
            {
                Console.WriteLine("fast");
            }
            //if speed <= 1000 ultra fast
            else if (speed <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            //if speed > 1000 extremely fast
            else if (speed > 1000)
                        {
                Console.WriteLine("extremely fast");
            }

            //output information
        }
    }
}
