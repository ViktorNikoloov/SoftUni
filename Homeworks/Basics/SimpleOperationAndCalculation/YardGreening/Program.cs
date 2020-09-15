    using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double m2 = double.Parse(Console.ReadLine());
            double price = m2 * 7.61;
            double discount = price * 0.18;
            double finalPrice = price - discount;

            Console.WriteLine($"The final price is: {finalPrice:F2} lv.");
            Console.WriteLine($"The discount is: {discount:F2} lv.");
           // Console.WriteLine(price);
        }

    }
}
