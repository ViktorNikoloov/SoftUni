using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using EasterRaces.Core.Contracts;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;

using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;

using EasterRaces.Repositories.Entities;

using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinValueOfParticipants = 3;
        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;

        private readonly IReadOnlyCollection<IDriver> orderedDrivers;

        private IDriver driver;
        private ICar car;
        private IRace race;

        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
            orderedDrivers = new List<IDriver>().AsReadOnly();
        }

        public string CreateDriver(string driverName)
        {
            if (driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);
            driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
                //TODO: Is messages correct ?
            }

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);

            }

            carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);

        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (carRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            //driverRepository.GetByName(driverName).AddCar(carRepository.GetByName(carModel));

            driver = driverRepository.GetByName(driverName);
            car = carRepository.GetByName(carModel);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            //raceRepository.GetByName(raceName).AddDriver(driverRepository.GetByName(driverName));

            driver = driverRepository.GetByName(driverName);
            race = raceRepository.GetByName(raceName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
                //TODO: Is messages correct ?
            }

            race = new Race(name, laps);

            raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var orderedDrivers = raceRepository
                .GetByName(raceName).Drivers
                .OrderByDescending(x => x.Car
                .CalculateRacePoints(raceRepository.GetByName(raceName).Laps))
                .ToList();

            if (orderedDrivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MinValueOfParticipants));
            }

            StringBuilder sb = new StringBuilder();
            sb
            .AppendLine(string.Format(OutputMessages.DriverFirstPosition, orderedDrivers[0].Name, raceName))
            .AppendLine(string.Format(OutputMessages.DriverSecondPosition, orderedDrivers[1].Name, raceName))
            .AppendLine(string.Format(OutputMessages.DriverThirdPosition, orderedDrivers[2].Name, raceName));

            return sb.ToString().TrimEnd();

        }
    }
}
