using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Raw_Data
{
    class Program
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = Console.ReadLine().Split();

                cars.Add(new Car(carData));
            }

            string cargoType = Console.ReadLine();

            if (cargoType == "fragile")
            {
                foreach (var car in cars.Where(x => x.CarsCargo.Type == "fragile"
                                            && x.CarsCargo.Weigth < 1000))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (cargoType == "flamable")
            {
                foreach (var car in cars.Where(x => x.CarsCargo.Type == "flamable"
                                            && x.CarsEngine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }

        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine CarsEngine { get; set; }
        public Cargo CarsCargo { get; set; }

        public Car(string[] carData)
        {
            this.Model = carData[0];

            this.CarsEngine = new Engine(int.Parse(carData[1]), int.Parse(carData[2]));

            this.CarsCargo = new Cargo(int.Parse(carData[3]), carData[4]);
        }
    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
    }

    class Cargo
    {
        public int Weigth { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            this.Weigth = weight;
            this.Type = type;
        }
    }
}