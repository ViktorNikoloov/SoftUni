using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();


            string[] tireCommand = Console.ReadLine().Split();
            while (tireCommand[0] != "No")
            {
                int length = tireCommand.Length / 2;
                int tireCounter = 0;

                Tire[] tire = new Tire[length];
                for (int i = 0; i < length; i++)
                {
                    int year = int.Parse(tireCommand[tireCounter]);
                    double pressure = double.Parse(tireCommand[tireCounter + 1]);
                    tire[i] = new Tire(year, pressure);
                    tireCounter += 2;
                }

                tires.Add(tire);
                tireCommand = Console.ReadLine().Split();
            }

            string[] engineCommand = Console.ReadLine().Split();
            while (engineCommand[0] != "Engines")
            {
                int horsePower = int.Parse(engineCommand[0]);
                double cubicCapacity = double.Parse(engineCommand[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                engineCommand = Console.ReadLine().Split();
            }

            string[] carCommand = Console.ReadLine().Split();
            while (carCommand[0] != "Show")
            {
                string make = carCommand[0];
                string model = carCommand[1];
                int year = int.Parse(carCommand[2]);
                double fuelQuantity = double.Parse(carCommand[3]);
                double fuelConsumption = double.Parse(carCommand[4]);
                Engine engine = engines[int.Parse(carCommand[5])];
                Tire[] tire = tires[int.Parse(carCommand[6])];

                Car newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tire);
                cars.Add(newCar);

                carCommand = Console.ReadLine().Split();
            }

            var specialCarss = cars.Where(y => y.Year >= 2017).Where(e => e.Engine.HorsePower > 330).Where(t=>t.Tires.Sum(p=>p.Pressure) >= 9 && t.Tires.Sum(p => p.Pressure) <= 10).ToList();
            var specialCars = cars.Where(c => c.Year >= 2017
            && c.Engine.HorsePower > 330
            && c.Tires.Sum(p => p.Pressure) >= 9
            && c.Tires.Sum(p => p.Pressure) <= 10).ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
