using System;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;


namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int NameMinSymbols = 5;

        private string name;

        public Driver(string name)
        {
            Name = name;
            CanParticipate = false;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < NameMinSymbols || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, Name, NameMinSymbols));
                }

                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(ICar), ExceptionMessages.CarInvalid);
            }

            Car = car;
            CanParticipate = true;
        }

        public void WinRace()
        =>  NumberOfWins++;
        
    }
}
