using System;
using System.Collections.Generic;

namespace _03.Speed_Racing
{
    class Program
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] car = Console.ReadLine().Split();

                cars.Add(new Car(car));
            }

            string[] driving = Console.ReadLine().Split();

            while (driving[0] != "End")
            {
                string model = driving[1];
                int distance = int.Parse(driving[2]);

                cars.Find(x => x.Model == model).Drive(distance);

                driving = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }

        }
    }

    class Car
    {
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumption { get; set; }
        public int DistanceTraveled { get; set; }

        public Car(string[] carStats)
        {
            this.Model = carStats[0];
            this.FuelAmount = decimal.Parse(carStats[1]);
            this.FuelConsumption = decimal.Parse(carStats[2]);
        }

        public void Drive(int distance)
        {
            decimal fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelAmount >= fuelNeeded)
            {
                this.DistanceTraveled += distance;
                this.FuelAmount -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}