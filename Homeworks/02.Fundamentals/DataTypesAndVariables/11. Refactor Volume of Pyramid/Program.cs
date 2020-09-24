using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double v = (length * width * height) / 3;

            Console.Write($"Length: Width: Height: Pyramid Volume: {v:f2}");
            //Length: Width: Height: Pyramid Volume: 9.00
        }
    }
}
