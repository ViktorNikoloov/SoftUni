using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsList = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "END") //
            {
                string direction = input[0];
                string car = input[1];

                if (input[0] == "IN")
                {
                    carsList.Add(car);
                }
                else
                {
                    if (carsList.Contains(car))
                    {
                        carsList.Remove(car);
                    }
                }



                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (carsList.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in carsList)
                {
                    Console.WriteLine(car);
                }
            }
            
        }
    }
}
