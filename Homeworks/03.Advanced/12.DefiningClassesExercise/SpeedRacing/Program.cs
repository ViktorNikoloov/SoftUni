using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(); //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            string[] driveInfo = Console.ReadLine().Split(); //"Drive {carModel} {amountOfKm}"
            while (driveInfo[0] != "End")
            {
                string carModel = driveInfo[1];
                int amountOfKm = int.Parse(driveInfo[2]);

                Car currCar = cars.FirstOrDefault(c => c.Model == carModel);
                currCar.Move(amountOfKm);

                driveInfo = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
