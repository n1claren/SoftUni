using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    class Race : IRace
    {
        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

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
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                name = value;
            }
        }

        public int Laps
        {
            get => laps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }

            if (driver.Car == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Any(d => d.Name == driver.Name))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }

            drivers.Add(driver);
        }
    }
}
