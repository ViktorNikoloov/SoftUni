using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //            •	Първи ред -брой пакети химикали. Цяло число в интервала[0...100]
            //•	Втори ред -брой пакети маркери. Цяло число в интервала[0...100]
            //•	Трети ред -литър препарат за почистване на дъска.Реално число в интервала[0.00…50.00]
            //•	Четвърти ред -процентът намаление.Цяло число в интервала[0...100]
            int pensils = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double litresOfCleaner = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            //Calculation
            //Да се отпечата на конзолата колко пари ще са нужни на Ани, за да си плати сметката.
            //•	Пакет химикали -5.80 лв
            //•	Пакет маркери -7.20 лв
            //•	Препарат - 1.20 лв(за литър)
            double totalSum = ((pensils * 5.8) + (markers * 7.2) + (litresOfCleaner * 1.2)) * (1 - (1.0 * discount / 100));

            //output    
            //Резултатът да се ФОРМАТИРА до третия знак след десетичната запетая.
            Console.WriteLine($"{totalSum:f3}");

        }
    }
}
