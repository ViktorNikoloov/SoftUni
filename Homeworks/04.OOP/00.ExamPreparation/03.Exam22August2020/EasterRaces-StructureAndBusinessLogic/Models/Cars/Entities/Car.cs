using System;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;


namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int ModelNameMinSymbols = 4;

        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;


        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (value.Length < ModelNameMinSymbols || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, Model, ModelNameMinSymbols));
                }

                model = value;
            }
        }

        public int HorsePower 
        { 
            get => horsePower;
            private set
            {
                if (HorsePower < minHorsePower || horsePower > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
                }

                horsePower = value;
            } 
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        => CubicCentimeters / HorsePower * laps;
    }
}
