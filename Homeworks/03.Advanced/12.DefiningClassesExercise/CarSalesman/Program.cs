using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Engine> engines = AddEngines();
            List<Car> cars = AddCars(engines);
            PrintCars(cars);

        }

        static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        static HashSet<Engine> AddEngines()
        {
            HashSet<Engine> engines = new HashSet<Engine>();

            int enginesLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesLines; i++)
            {
                string[] enginesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); //"{model} {power} {displacement} {efficiency}"

                string model = enginesInfo[0];
                int power = int.Parse(enginesInfo[1]);

                Engine engine = null;
                if (enginesInfo.Length == 4)
                {
                    string displacement = enginesInfo[2];
                    string efficiency = enginesInfo[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (enginesInfo.Length == 3)
                {
                    string currunt = enginesInfo[2];

                    if (char.IsDigit(currunt[0]))
                    {
                        engine = new Engine(model, power, currunt);
                    }
                    else
                    {
                        engine = new Engine(power, model, currunt);
                    }

                }
                else if (enginesInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);

            }
            return engines;
        }

        static List<Car> AddCars(HashSet<Engine> engines)
        {
            List<Car> cars = new List<Car>();
            int carLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < carLines; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); //"{model} {engine} {weight} {color}"

                string model = carInfo[0];
                string currEngine = carInfo[1];

                Engine engine = FindEngine(engines, currEngine);

                Car car = null;
                if (carInfo.Length == 4)
                {
                    string weight = carInfo[2];
                    string color = carInfo[3];
                    car = new Car(model, engine, weight, color);

                    car.Weight = weight;
                    car.Color = color;
                }
                else if (carInfo.Length == 3)
                {
                    string currunt = carInfo[2];

                    if (char.IsDigit(currunt[0]))
                    {
                        car = new Car(model, engine, currunt);
                    }
                    else
                    {
                        car = new Car(engine, model, currunt);
                    }
                }
                else if (carInfo.Length == 2)
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }
            return cars;
        }

        static Engine FindEngine(HashSet<Engine> engines, string model)
        {
            Engine engine = null;

            foreach (var item in engines)
            {
                if (item.Model == model)
                {
                    engine = item;
                }
            }

            return engine;
        }


    }
}


