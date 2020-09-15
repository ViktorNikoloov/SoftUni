using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            //tank capacity 255liters

            int n = int.Parse(Console.ReadLine());
            int capacity = 255;

            for (int i = 0; i < n; i++)
            {
                int liers = int.Parse(Console.ReadLine());
                if (liers <= capacity)
                {
                    capacity -= liers;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!"); 
                }
            }
            Console.WriteLine(255 - capacity);
        }
    }
}
