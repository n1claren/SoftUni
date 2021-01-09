using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();

            string vehicle = string.Empty;

            while ((vehicle = Console.ReadLine()) != "End")
            {
                var vehicleSpecs = vehicle
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string vehicleType = vehicleSpecs[0];
                string vehicleModel = vehicleSpecs[1];
                string vehicleColor = vehicleSpecs[2];
                double vehicleHorsePower = double.Parse(vehicleSpecs[3]);

                if (vehicleType == "truck")
                {
                    Truck truck = new Truck();

                    truck.Model = vehicleModel;
                    truck.Color = vehicleColor;
                    truck.HorsePower = vehicleHorsePower;

                    trucks.Add(truck);
                }
                else
                {
                    Car car = new Car();

                    car.Model = vehicleModel;
                    car.Color = vehicleColor;
                    car.HorsePower = vehicleHorsePower;

                    cars.Add(car);
                }
            }

            string model = string.Empty;

            double averageCarHP = 0.0;
            double averageTruckHP = 0.0;

            foreach (var car in cars)
            {
                averageCarHP += car.HorsePower;
            }

            foreach (var truck in trucks)
            {
                averageTruckHP += truck.HorsePower;
            }

            averageCarHP = averageCarHP / cars.Count;
            averageTruckHP = averageTruckHP / trucks.Count;

            while ((model = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (var car in cars)
                {     
                    if (car.Model == model)
                    {
                        Console.WriteLine("Type: Car");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Horsepower: {car.HorsePower}");
                    }
                }

                foreach (var truck in trucks)
                {
                    if (truck.Model == model)
                    {
                        Console.WriteLine("Type: Truck");
                        Console.WriteLine($"Model: {truck.Model}");
                        Console.WriteLine($"Color: {truck.Color}");
                        Console.WriteLine($"Horsepower: {truck.HorsePower}");
                    }
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarHP:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTruckHP:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }

        }
    }

    class Truck
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }

    class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }
}
