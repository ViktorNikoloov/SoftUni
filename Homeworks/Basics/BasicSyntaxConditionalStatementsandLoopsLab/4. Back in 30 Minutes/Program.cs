using System;

namespace _4._Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int finalHours = 0;
            int finalMin = hours * 60 + minutes + 30;

            while (finalMin >= 60)
            {
                if (finalMin > 59)
                {
                    finalHours += 1;
                    finalMin -= 60;
                }
                if (finalHours > 23)
                {
                    finalHours = 0;
                }
            }
            
            Console.WriteLine($"{finalHours}:{finalMin:d2}");
        }
    }
}
