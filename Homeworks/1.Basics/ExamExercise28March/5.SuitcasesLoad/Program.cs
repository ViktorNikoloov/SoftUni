using System;

namespace _5.SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            //Капацитетът на багажника – реално число в диапазона [100.0…6000.0]
            double capacity = double.Parse(Console.ReadLine());
            double allBaggageCap = capacity;
            int baggageCounter = 0;


            //до получаване на команда "End" или до запълване на багажника, се чете по един ред:
            //обем на куфар – реално число.
            string command = Console.ReadLine();
            while (command != "End")
            {

                double baggage = double.Parse(command);
                baggageCounter++;

                if (baggageCounter % 3 == 0)
                {
                    baggage *= 1.1;
                }
                if (baggage > allBaggageCap)
                {
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {baggageCounter - 1} suitcases loaded.");
                    break;
                }

                allBaggageCap -= baggage;
                command = Console.ReadLine();

            }

            if (command == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
                Console.WriteLine($"Statistic: {baggageCounter} suitcases loaded.");
            }

        }
    }
}
