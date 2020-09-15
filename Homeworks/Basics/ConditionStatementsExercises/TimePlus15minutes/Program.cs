using System;

namespace TimePlus15minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Да се напише програма, която чете час и минути 
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            min += 15;
            //изчислява колко ще е часът след 15 минути ?
            if (min <= 60)
            {
                min -= 60;
                hour += 1;
            }


            if (hour == 24)
            {
                hour = 0;

            }
            
            if (min <= 9)
            {
                Console.WriteLine($"{hour}:0{min}");
            }

            else
            {
                Console.WriteLine($"{hour}:{min}");
            }
        }
    }
}
