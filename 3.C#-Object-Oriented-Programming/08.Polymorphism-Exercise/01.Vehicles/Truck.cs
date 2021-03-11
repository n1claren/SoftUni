using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : IVehicle
    {
        public Truck(double fq, double fc)
        {
            FuelQuantity = fq;
            FuelConsumptionPerKM = fc + 1.6;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumptionPerKM { get; set; }

        public void Drive(double km)
        {
            if (FuelQuantity >= FuelConsumptionPerKM * km)
            {
                FuelQuantity -= FuelConsumptionPerKM * km;

                Console.WriteLine($"Truck travelled {km} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void Refuel(double fuel)
        {
            FuelQuantity += (fuel / 100) * 95;
        }
    }
}
