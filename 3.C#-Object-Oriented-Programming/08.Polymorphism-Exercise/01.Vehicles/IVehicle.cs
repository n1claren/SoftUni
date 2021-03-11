using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; set; }
        double FuelConsumptionPerKM { get; set; }
        void Drive(double km);
        void Refuel(double fuel);
    }
}
