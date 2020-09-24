using System;

namespace EasterBakery
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Цена на брашното за един килограм – реално число в интервала [0.00 … 10000.00]
            //Килограми на брашното – реално число в интервала [0.00 … 10000.00]
            //Килограми на захарта – реално число в интервала [0.00 … 10000.00]
            //Брой кори с яйца – цяло число в интервала [0 … 10000]
            //Пакети мая  – цяло число в интервала [0 … 10000]
            double breadPrice = double.Parse(Console.ReadLine());
            double breadKilo = double.Parse(Console.ReadLine());
            double sugarKilo = double.Parse(Console.ReadLine());
            int eggNum = int.Parse(Console.ReadLine());
            int yest = int.Parse(Console.ReadLine());

            //calculation
            //цената на килограм захар е с 25% по-ниска от тази на килограм брашно
            //цената на една кора с яйца е с 10% по-висока от цената на килограм брашно
            //цената на един пакет мая е с 80% по-ниска от цената на килограм захар
            double sugarPrice = (breadPrice * 0.75);
            double eggsPrice = (breadPrice * 1.10);
            double yestPrice = (sugarPrice * 0.20);
            double totalSum = (breadPrice * breadKilo) + (sugarPrice * sugarKilo) + (eggNum * eggsPrice) + (yest * yestPrice);

            //output
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
