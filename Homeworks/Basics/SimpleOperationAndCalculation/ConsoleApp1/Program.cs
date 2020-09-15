using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            // 1.	Кв. метри, които ще бъдат озеленени – реално число в интервала [0.00… 10000.00]
            //7.61лв със ДДС
            //18%

            double meters = double.Parse(Console.ReadLine());
            double price = meters * 7.61;
            double percent = 18 *0.01;
            double discount = price * percent;
            double totalsum = price - discount;

            //output
            // •	"The final price is: {крайна цена на услугата} lv."
            //•	"The discount is: {отстъпка} lv."
            //И двете суми трябва да бъдат форматирани до втората цифра след десетичния знак.

            Console.WriteLine($"The final price is: {totalsum:F2} lv.");
            Console.WriteLine($"The tiscount is: {discount:F2} lv.");
            Console.WriteLine($"The final price is: {price * (1 - percent):F2} lv.");
            Console.WriteLine(1-percent);
            


        }
    }
}
