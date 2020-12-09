using System;
using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int NameMinSymbols = 5;
        private const int LabsMinValue= 1;

        private string name;
        private int laps;

        private readonly ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;

            drivers = new List<IDriver>();
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

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < LabsMinValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, LabsMinValue));
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers
            => (IReadOnlyCollection<IDriver>)drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(IDriver), ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if(drivers.Any(d=>d.Name == driver.Name))
            {
                throw new ArgumentNullException(nameof(IDriver), string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }

            drivers.Add(driver);
        }
    }
}
