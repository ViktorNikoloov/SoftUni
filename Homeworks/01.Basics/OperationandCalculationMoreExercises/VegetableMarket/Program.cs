using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Градинар продавал реколтата от градината си на зеленчуковата борса. Продава зеленчуци за N лева на килограм и плодове за M лева за килограм. 
           
            //input
            // От конзолата се четат 4 числа, по едно на ред:
            //•	Първи ред – Цена за килограм зеленчуци – реално число[0.00… 1000.00]
            //•	Втори ред – Цена за килограм плодове – реално число[0.00… 1000.00]
            //•	Трети ред – Общо килограми на зеленчуците – цяло число[0… 1000]
            //•	Четвърти ред – Общо килограми на плодовете – цяло число[0… 1000]
            double priceVegetable = double.Parse(Console.ReadLine());
            double priceFruit = double.Parse(Console.ReadLine());
            double vegetableKg = double.Parse(Console.ReadLine());
            double fruitKg = double.Parse(Console.ReadLine());

            //Calculation
            //Напишете програма, която да пресмята приходите от реколтата в евро ( ако приемем, че едно евро е равно на 1.94лв).
            double vegetableSum = priceVegetable * vegetableKg;
            double fruitSum = priceFruit * fruitKg;
            double totalSum = vegetableSum + fruitSum;
            double totalSumEuro = totalSum / 1.94;

            //output
            //Да се отпечата на конзолата едно число: приходите от всички плодове и зеленчуци в евро.
            //Резултата да се форматира до втория знак след десетичния разделител.
            Console.WriteLine($"{totalSumEuro:F2}");


        }
    }
}
