using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamRetake10AprilTask3
{
    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(int mileage, int fuel)
        {
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carsInfo = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries); //{car}|{mileage}|{fuel}
                Car car = new Car(int.Parse(carsInfo[1]), int.Parse(carsInfo[2]));
                cars.Add(carsInfo[0], car);
            }

            string[] command = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            while (!command.Contains("Stop"))
            {
                string car = command[1];

                if (command.Contains("Drive")) //•	Drive : {car} : {distance} : {fuel} 
                {
                    int distance = int.Parse(command[2]);
                    int fuel = int.Parse(command[3]);

                    if (cars[car].Fuel >= fuel)
                    {
                        cars[car].Mileage += distance;
                        cars[car].Fuel -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                    if (cars[car].Mileage >= 100000)
                    {
                        cars.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }
                if (command.Contains("Refuel")) //•	Refuel : {car} : {fuel}
                {
                    int fuel = int.Parse(command[2]);

                    if (cars[car].Fuel + fuel <= 75)
                    {
                        cars[car].Fuel += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{car} refueled with {75 - cars[car].Fuel} liters");
                        cars[car].Fuel = 75;

                    }
                }
                if (command.Contains("Revert")) // •Revert : {car} : {kilometers}
                {
                    int amountReverted = int.Parse(command[2]);
                    cars[car].Mileage -= amountReverted;

                    if (cars[car].Mileage >= 10000)
                    {
                        Console.WriteLine($"{car} mileage decreased by {amountReverted} kilometers");
                    }
                    else
                    {
                        cars[car].Mileage = 10000;
                    }

                }

                command = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            // cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key);

            foreach (var item in cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Mileage} kms, Fuel in the tank: {item.Value.Fuel} lt.");
            }

        }
    }
}
