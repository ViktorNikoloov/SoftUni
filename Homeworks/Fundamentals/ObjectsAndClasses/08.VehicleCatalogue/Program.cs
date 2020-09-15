using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Catalog catalog = new Catalog();
            catalog.Cars = new List<Car>();
            catalog.Trucks = new List<Truck>();

            while (command != "end")
            {
                string[] details = command.Split("/").ToArray(); //{type}/{brand}/{model}/{horse power / weight}
                

                if (details[0] == "Car")
                {
                    Car car = new Car();
                    car.Brand = details[1];
                    car.Model = details[2];
                    car.Power = double.Parse(details[3]);
                    catalog.Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck();
                    truck.Brand = details[1];
                    truck.Model = details[2];
                    truck.Weight = double.Parse(details[3]);
                    catalog.Trucks.Add(truck);
                }

                command = Console.ReadLine();
            }
            List<Car> orderedCars = catalog.Cars.OrderBy(a => a.Brand).ToList();
            List<Truck> orderedTrucks = catalog.Trucks.OrderBy(a => a.Brand).ToList();

            if (orderedCars.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.Power}hp");
                }
            }

            if (orderedTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }

    class Truck //Brand, Model and Weight.
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    class Car //Brand, Model and Power.
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Power { get; set; }

        
    }

    class Catalog //Collections of Trucks and Cars.
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

       
    }
}
