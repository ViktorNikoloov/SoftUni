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
                if (string.IsNullOrWhiteSpace(value) || value.Length < ModelNameMinSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, ModelNameMinSymbols));
                }

                model = value;
            }
        }

        public int HorsePower 
        { 
            get => horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            } 
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        => CubicCentimeters / HorsePower * laps;
    }
}
