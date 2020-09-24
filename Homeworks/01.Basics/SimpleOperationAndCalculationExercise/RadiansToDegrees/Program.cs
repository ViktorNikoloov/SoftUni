using System;

namespace RadiansToDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            // Използвайте формулата: градус = радиан * 180 / π
            double rad = double.Parse(Console.ReadLine());
            double deg = rad * 180 / Math.PI;
            Console.WriteLine(Math.Round(deg));
        }
    }
}
