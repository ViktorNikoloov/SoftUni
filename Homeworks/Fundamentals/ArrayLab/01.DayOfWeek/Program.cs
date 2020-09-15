using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] dayOfWeeks = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] dayOfWeeks = new string[7];
            dayOfWeeks[0] = "Monday";
            dayOfWeeks[1] = "Tuesday";
            dayOfWeeks[2] = "Wednesday";
            dayOfWeeks[3] = "Thursday";
            dayOfWeeks[4] = "Friday";
            dayOfWeeks[5] = "Saturday";
            dayOfWeeks[6] = "Sunday";

            int number = int.Parse(Console.ReadLine());
            if (1 <= number && number <= 7)
            {
            Console.WriteLine(dayOfWeeks[number - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
