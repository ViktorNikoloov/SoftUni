using System;

namespace EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            //input 
            //1.Плод - текст с възможности: "Watermelon", "Mango", "Pineapple" или "Raspberry"
            //2.Размерът на сета -текст с възможности: "small" или "big"
            //3.Брой на поръчаните сетове - цяло число в интервала[1 … 10000]
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int numbers = int.Parse(Console.ReadLine());
            double PackagePrice = 0;
            //calculation   

            switch (size)
            {
                case "small": // 2pc
                    switch (fruit)
                    {
                        case "Watermelon":
                            PackagePrice = 2 * 56.00;
                            break;

                        case "Mango":
                            PackagePrice = 2 * 36.66;
                            break;

                        case "Pineapple":
                            PackagePrice = 2 * 42.10;
                            break;

                        case "Raspberry":
                            PackagePrice = 2 * 20.00;
                            break;
                    }
                    break;

                        case "big": // 5pc
                    switch (fruit)
                    {
                        case "Watermelon":
                            PackagePrice = 5 * 28.70;
                            break;

                        case "Mango":
                            PackagePrice = 5 * 19.60;
                            break;

                        case "Pineapple":
                            PackagePrice = 5 * 24.80;
                            break;

                        case "Raspberry":
                            PackagePrice = 5 * 15.20;
                            break;
                    }
                    break;
            }

            double totalPrice = numbers * PackagePrice;
            
            //•	от 400 лв. до 1000 лв. включително има 15% отстъпка
            //•	над 1000 лв. има 50% отстъпка
            if (400 <= totalPrice && totalPrice <= 1000)
            {
                totalPrice *= 0.85;
            }
            if (totalPrice > 1000)
            {
                totalPrice *= 0.50;
            }
            //•	Цената, която трябва да се заплати, форматирана до втория знак след десетичната запетая, 
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
