using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conditional
            //Да се напише програма, в която потребителят въвежда вида и размерите на геометрична фигура и пресмята лицето й.

            //input         
                string figure = Console.ReadLine();

            // Calculation
            if (figure == "square")
            {
                double square = double.Parse(Console.ReadLine());
                Console.WriteLine($"{square * square:f3}");
            }
            else if (figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double area = sideA * sideB;
                Console.WriteLine($"{area:f3}");
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double area = Math.PI * r * r;
                Console.WriteLine($"{area:f3}");

            }
            else if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double area = side * h / 2;
                Console.WriteLine($"{area:f3}");

            }


            

        }
    }
}
