using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();

                string model = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];
                int counter = 5;
                for (int g = 0; g < tires.Length; g++)
                {
                    double pressure = double.Parse(carInfo[counter]);
                    int age = int.Parse(carInfo[counter + 1]);

                    Tire tire = new Tire(pressure, age);
                    tires[g] = tire;

                    counter += 2;
                }
                
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
                
            }

            string command = Console.ReadLine();
            if (command== "fragile")
            {
                var fragileCars = cars.Where(x => x.Cargo.Type == "fragile"
                && x.Tires.Any(p => p.Pressure < 1)).ToList();

                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                var flamableCars = cars.Where(x => x.Cargo.Type == "flamable" 
                && x.Engine.Power > 250).ToList();

                foreach (var car in flamableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
