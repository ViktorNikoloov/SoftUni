using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier date = new DateModifier();
            int result = date.GetDaysDifference(startDate, endDate);

            Console.WriteLine(result);
        }
    }
}
