using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogNum = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());
            double dogFood = dogNum * 2.50;
            double otherFood = otherAnimals * 4.0;
            double total = dogFood + otherFood;
            Console.WriteLine("{0:F2} lv.", total);
            //Console.WriteLine($"{total:f2} lv.");      

        }
    }
}
