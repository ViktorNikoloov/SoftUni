using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedProduct(Console.ReadLine(), int.Parse(Console.ReadLine()));
        }

        static void OrderedProduct(string name, double quantity)
        {
            //•	coffee – 1.50
            //•	water – 1.00
            //•	coke – 1.40
            //•	snacks – 2.00
            if (name == "coffee")
            {
                Console.WriteLine($"{1.5 * quantity:f2}");
            }
            else if (name == "water")
            {
                Console.WriteLine($"{1.0 * quantity:f2}");
            }
            else if (name == "coke")
            {
                Console.WriteLine($"{1.4 * quantity:f2}");
            }
            else if (name == "snacks")
            {
                Console.WriteLine($"{2.0 * quantity:f2}");
            }


        }
    }
}
