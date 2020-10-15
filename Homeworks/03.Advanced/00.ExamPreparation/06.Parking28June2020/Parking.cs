using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            cars = new List<Car>();
        }

        private List<Car> cars;

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count
            => cars.Count;

        //•	Method Add(Car car) – adds an entity to the data if there is an empty cell for the car.
        public void Add(Car car)
        {
            if(cars.Count != Capacity)
            {
                cars.Add(car);
            }
        }

        //•	Method Remove(string manufacturer, string model) – removes the car by given manufacturer and model, if such exists, and returns bool.
        public bool Remove(string manufacturer, string model)
        {
            //Car remove = null;
            //foreach (var car in cars)
            //{
            //    if (car.Manufacturer == manufacturer && car.Model == model)
            //    {
            //        remove = car;
            //    }
            //}
            
            Car car = cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return cars.Remove(car);
            
        }

        //•	Method GetLatestCar() – returns the latest car(by year) or null if have no cars.
        public Car GetLatestCar()
        {
            Car theLatestCar = null;
            int year = 0;
            foreach (var car in cars)
            {
                if (car.Year >= year)
                {
                    theLatestCar = car;
                    year = car.Year;
                }
            }

            return theLatestCar;
        }

        //•	Method GetCar(string manufacturer, string model) – returns the car with the given manufacturer and model or null if there is no such car.
        public Car GetCar(string manufacturer, string model)
        => cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().Trim();
        }

    }

}
