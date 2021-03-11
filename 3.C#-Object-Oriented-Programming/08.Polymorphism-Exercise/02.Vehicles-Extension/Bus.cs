using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Bus : IVehicle
    {
        private double fuelQuantity;
        public Bus(double fq, double fc, double tc)
        {
            TankCapacity = tc;
            FuelQuantity = fq;
            FuelConsumptionPerKM = fc;
        }
        public double FuelQuantity
        {
            get => fuelQuantity;

            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumptionPerKM { get; set; }
        public double TankCapacity { get; set; }


        public void Drive(double km)
        {
            if (FuelQuantity >= (FuelConsumptionPerKM + 1.4) * km)
            {
                FuelQuantity -= (FuelConsumptionPerKM + 1.4)* km;

                Console.WriteLine($"Bus travelled {km} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double km)
        {
            if (FuelQuantity >= FuelConsumptionPerKM * km)
            {
                FuelQuantity -= FuelConsumptionPerKM * km;

                Console.WriteLine($"Bus travelled {km} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void Refuel(double fuel)
        {
            if (fuelQuantity + fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                FuelQuantity += fuel;
            }
        }
    }
}
