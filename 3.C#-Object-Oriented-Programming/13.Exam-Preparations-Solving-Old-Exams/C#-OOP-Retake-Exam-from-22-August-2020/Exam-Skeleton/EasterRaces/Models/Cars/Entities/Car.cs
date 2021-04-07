using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;


namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHP;
        private int maxHP;

        public Car(
            string model, 
            int horsePower, 
            double cubicCentimeters, 
            int minHorsePower, 
            int maxHorsePower)
        {
            CubicCentimeters = cubicCentimeters;
            minHP = minHorsePower;
            maxHP = maxHorsePower;

            Model = model;
            HorsePower = horsePower;
        }

        public string Model
        {
            get => model;

            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;

            private set
            {
                if (value < minHP || value > maxHP)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return (CubicCentimeters / HorsePower) * laps;
        }
    }
}
