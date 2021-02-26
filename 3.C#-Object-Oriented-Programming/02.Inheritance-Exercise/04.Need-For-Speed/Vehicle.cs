using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption 
        {
            get { return defaultFuelConsumption; }
        }

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuelConsumed = this.FuelConsumption * kilometers;

            this.Fuel -= fuelConsumed;
        }
    }
}
