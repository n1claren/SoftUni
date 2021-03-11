using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : IVehicle
    {
        public Car(double fq, double fc)
        {
            FuelQuantity = fq;
            FuelConsumptionPerKM = fc + 0.9;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumptionPerKM { get; set; }

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
            FuelQuantity += fuel;
        }
    }
}
