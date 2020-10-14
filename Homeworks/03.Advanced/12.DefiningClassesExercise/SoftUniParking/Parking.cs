using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count
        //=> cars.Count;
        {
            get
            {
                return cars.Count;
            }

        }

        public string AddCar(Car car)
        {
            //bool exists = cars.Any(x => x.RegistrationNumber == car.RegistrationNumber);
            //if (exists)
            //{
            //    return "Car with that registration number, already exists!";
            //}

            //cars.Add(car);
            //return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

            foreach (var currCar in cars)
            {
                if (currCar.RegistrationNumber.Contains(car.RegistrationNumber))
                {
                    return "Car with that registration number, already exists!";
                }
            }

            if (capacity == cars.Count)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            //Car car = cars.FirstOrDefault(X => X.RegistrationNumber == registrationNumber);
            //if (car == null)
            //{
            //    return "Car with that registration number, doesn't exist!";
            //}
            //cars.Remove(car);
            //return $"Successfully removed {registrationNumber}";

            foreach (var car in cars)
            {
                if (car.RegistrationNumber.Contains(registrationNumber))
                {
                    //cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
                    cars.Remove(car);
                    return $"Successfully removed {registrationNumber}";
                }

            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        //=> cars.FirstOrDefault(x=>x.RegistrationNumber == registrationNumber);
        {
            Car returnedCar = null;
            foreach (var car in cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    returnedCar = car;
                }
            }
            return returnedCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                //Car car = cars.FirstOrDefault(x => x.RegistrationNumber == number);
                //cars.Remove(car);

                Car newCar = null;
                foreach (var car in cars)
                {
                    if (number == car.RegistrationNumber)
                    {
                        newCar = car;
                    }
                }

                cars.Remove(newCar);
            }
        }


    }
}
