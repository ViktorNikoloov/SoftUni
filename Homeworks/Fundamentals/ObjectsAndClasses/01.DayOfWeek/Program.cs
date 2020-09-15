using System;
using System.ComponentModel;
using System.Globalization;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDate = Console.ReadLine();

            DateTime date = DateTime.ParseExact(inputDate, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);
            


        }
    }
}
