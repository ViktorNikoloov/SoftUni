using System;
using System.Collections.Generic;
using System.Net;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();

            int enginesLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesLines; i++)
            {
                string[] enginesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); //"{model} {power} {displacement} {efficiency}"

                string model = enginesInfo[0];
                int power = int.Parse(enginesInfo[1]);
                Engine engine = new Engine(model, power);
                if (enginesInfo.Length == 4)
                {
                    engine.Displacement = enginesInfo[2];
                    engine.Efficiency = enginesInfo[3];

                }
                else if (enginesInfo[2].Length > 1)
                {
                    engine.Displacement = enginesInfo[2];
                }
                else
                {
                    engine.Efficiency = enginesInfo[2];
                }

                if (!engines.ContainsKey(model))
                {
                    engines.Add(model, new Engine());
                    engines[model] = engine;
                }
                else
                {
                    engines[model] = engine;

                }

            }

            int carLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < carLines; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries); //"{model} {engine} {weight} {color}"
                string model = carInfo[0];

                Engine engine = engines[carInfo[1]];
                Car car = new Car(model, engine);

                if (carInfo.Length == 4)
                {
                    string weight = carInfo[2];
                    string color = carInfo[3];

                    car.Weight = weight;
                    car.Color = color;
                }
                else if (carInfo.Length > 2)
                {
                    char[] curr = carInfo[2].ToCharArray();
                    if (char.IsDigit(curr[0]))
                    {
                        string weight = carInfo[2];
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = carInfo[2];
                        car.Color = color;
                    }
                }
                if (!cars.Contains(car))
                {
                    cars.Add(car);
                }
                

            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString()); 
            }

        }
    }
}

