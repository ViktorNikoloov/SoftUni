using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            //Първи ред – месеците за които се търси средният разход – цяло число в интервала [1...100]
            int mounths = int.Parse(Console.ReadLine());

            double electricityBills = 0;
            double waterBills = 0;
            double internetBills = 0;
            double otherBills = 0;
            

            //За всеки месец – сметката за ток – реално число в интервала[1.00...1000.00]
            for (int i = 0; i < mounths; i++)
            {
                double electricity = double.Parse(Console.ReadLine());
                electricityBills += electricity;
                waterBills += 20;
                internetBills += 15;
            }

            otherBills += (electricityBills + waterBills + internetBills) * 1.2;
            double averageBills = (electricityBills + waterBills + internetBills + otherBills) / mounths;

            Console.WriteLine($"Electricity: {electricityBills:f2} lv");
            Console.WriteLine($"Water: {waterBills:f2} lv");
            Console.WriteLine($"Internet: {internetBills:f2} lv");
            Console.WriteLine($"Other: {otherBills:f2} lv");
            Console.WriteLine($"Average: {averageBills:f2} lv");
        }
    }
}
