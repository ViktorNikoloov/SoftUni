using System;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //магнолии – цяло число в интервала [0 … 50]
            //зюмбюли – цяло число в интервала [0 … 50]
            //рози – цяло число в интервала [0 … 50]
            //kактуси – цяло число в интервала [0 … 50]
            //Цена на подаръка – реално число в интервала [0.00 … 500.00]
            int magnolii = int.Parse(Console.ReadLine());
            int zumbul = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int kaktus = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            // Calculation
            double totalSum = 0;
            totalSum += magnolii * 3.25 + zumbul * 4.0 + roses * 3.5 + kaktus * 8;
            //Магнолии – 3.25 лева
            //Зюмбюли – 4 лева
            //Рози – 3.50 лева
            //Кактуси – 8 лева
            //От общата сума, Мария трябва да плати 5% данъци.
            totalSum *= 0.95;
            //Ако парите СА стигнали: 
            if (totalSum >= price)
            {
                Console.WriteLine($"She is left with {Math.Floor(totalSum - price)} leva.");
            }
            // сумата трябва да е закръглена към по-малко цяло число (пр. 1.90 -> 1).
            //Ако парите НЕ достигат: 
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(price - totalSum)} leva.");
            }
            //–сумата трябва да е закръглена към по-голямо цяло число (пр. 1.10 -> 2).
        }
    }
}
