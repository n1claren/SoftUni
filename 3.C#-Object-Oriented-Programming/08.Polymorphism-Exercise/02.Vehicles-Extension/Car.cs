using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : IVehicle
    {
        private double fuelQuantity;
        public Car(double fq, double fc, double tc)
        {
            TankCapacity = tc;
            FuelQuantity = fq;
            FuelConsumptionPerKM = fc + 0.9;
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
            if (FuelQuantity >= FuelConsumptionPerKM * km)
            {
                FuelQuantity -= FuelConsumptionPerKM * km;

                Console.WriteLine($"Car travelled {km} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
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
