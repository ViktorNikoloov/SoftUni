using System;

namespace _9.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	The amount of money Ivan Cho has – floating-point number in range [0.00…1,000.00]
            //•	The count of students – integer in range[0…100]
            //•	The price of lightsabers for a single sabre – floating - point number in range[0.00…100.00]
            //•	The price of robes for a single robe – floating - point number in range[0.00…100.00]
            //•	The price of belts for a single belt – floating - point number in range[0.00…100.00]

            double ivanMoney = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabers = double.Parse(Console.ReadLine());
            double robes = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());

            //calculate
            double extraSabers = Math.Ceiling(students * 0.1);
            int freeBelts = students / 6;
            double totalPrice = (students + extraSabers) * lightsabers + (students * robes) + (students - freeBelts) * belts;

            if (totalPrice <= ivanMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalPrice - ivanMoney:f2}lv more.");
            }
        }
    }
}
