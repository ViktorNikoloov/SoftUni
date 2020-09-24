using System;

namespace Trapeziod_Area_ЛицеНаТрапец_
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Напишете програма, която чете от конзолата три числа b1, b2 и h и пресмята лицето на трапец.
            double b1 = double.Parse(Console.ReadLine());   
            double b2 = double.Parse(Console.ReadLine());   
            double h = double.Parse(Console.ReadLine());

            //Calculation
            //Формулата за лице на трапец е (b1 + b2) * h / 2.
            double area = (b1 + b2) * h / 2;

            //output

            Console.WriteLine($"{area:F2}");



        }
    }
}
