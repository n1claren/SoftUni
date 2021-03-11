using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; set; }
        double FuelConsumptionPerKM { get; set; }
        double TankCapacity { get; set; }
        void Drive(double km);
        void Refuel(double fuel);
    }
}
