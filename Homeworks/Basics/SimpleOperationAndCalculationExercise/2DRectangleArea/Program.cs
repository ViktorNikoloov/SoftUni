using System;

namespace _2DRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double lendgth = Math.Abs(x1 - x2);
            double wedth = Math.Abs(y1 - y2);

            double area = lendgth * wedth;
            double per = 2 * (lendgth + wedth);

            Console.WriteLine("{0:F2}", area);
            Console.WriteLine($"{per:F2}");

          

        }
    }
}
