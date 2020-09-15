using System;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Напишете програма, която чете от конзолата страна и височина на триъгълник и пресмята неговото лице.
            double sideA = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());


            //Calculation
            //Използвайте формулата за лице на триъгълник: area = a * h / 2. 
            double area = (sideA * h) / 2;

            //output
            //Форматирате изхода до втория знак след десетичната запетая.

            Console.WriteLine($"{area:F2}");
        }
    }
}
