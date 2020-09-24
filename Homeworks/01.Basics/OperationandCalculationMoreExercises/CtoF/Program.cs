using System;

namespace CtoF
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Напишете програма, която чете градуси по скалата на Целзий (°C) и ги преобразува до градуси по скалата на Фаренхайт (°F). 
            double C = double.Parse(Console.ReadLine());

            //Calculation
            //формулата T(°F) = T(°C) × 1.8 + 32 
            double F = (C * 1.8) + 32;

            //output
            //Форматирате изхода до втория знак след десетичната запетая. 
            Console.WriteLine($"{F:F2}");


        }
    }
}
