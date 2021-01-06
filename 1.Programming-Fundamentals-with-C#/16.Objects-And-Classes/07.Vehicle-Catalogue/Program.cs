using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (input != "end")
            {
                string[] inputCollection = input.Split("/");

                string type = inputCollection[0];
                string brand = inputCollection[1];
                string model = inputCollection[2];
                int numeric = int.Parse(inputCollection[3]);

                if (type?.ToLower() == "car")
                {
                    Car car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = numeric;

                    cars.Add(car);
                }

                if (type?.ToLower() == "truck")
                {
                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = numeric;

                    trucks.Add(truck);
                }

                input = Console.ReadLine();
            }

            List<Car> carsResult = cars.OrderBy(x => x.Brand).ToList();
            List<Truck> trucksResult = trucks.OrderBy(x => x.Brand).ToList();

            if (carsResult.Count > 0)
            {
                Console.WriteLine("Cars:");
                for (int i = 0; i < carsResult.Count; i++)
                {
                    Console.WriteLine($"{carsResult[i].Brand}: {carsResult[i].Model} - {carsResult[i].HorsePower}hp");
                }
            }

            if (trucksResult.Count > 0)
            {
                Console.WriteLine("Trucks:");
                for (int i = 0; i < trucksResult.Count; i++)
                {
                    Console.WriteLine($"{trucksResult[i].Brand}: {trucksResult[i].Model} - {trucksResult[i].Weight}kg");
                }
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }

    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
