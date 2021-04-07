using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepository;
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = carRepository.GetByName(carModel);
            IDriver driver = driverRepository.GetByName(driverName);

            if (car == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            if (driver == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driver.Name, car.Model);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = driverRepository.GetByName(driverName);
            IRace race = raceRepository.GetByName(raceName);

            if (driver == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (race == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driver.Name, race.Name);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            else if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            if (carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);

            driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);

            raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, race.Name);
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = raceRepository.GetByName(raceName);

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.RaceInvalid, race.Name, 3));
            }

            var top3Drivers = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var firstDriver = top3Drivers[0];
            var secondDriver = top3Drivers[1];
            var thirdDriver = top3Drivers[2];

            firstDriver.WinRace();
            raceRepository.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, firstDriver.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, secondDriver.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, thirdDriver.Name, race.Name));

            return sb.ToString().Trim();
        }
    }
}
