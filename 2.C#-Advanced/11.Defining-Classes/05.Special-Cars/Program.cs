using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            string tireInput = string.Empty;

            List<List<Tire>> tires = new List<List<Tire>>();

            while ((tireInput = Console.ReadLine()) != "No more tires")
            {
                double[] splittedInput = tireInput
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                List<Tire> temp = new List<Tire>();

                for (int i = 0; i < splittedInput.Length - 1; i+=2)
                {
                    int year = (int)splittedInput[i];
                    double pressure = splittedInput[i + 1];

                    Tire temporary = new Tire(year, pressure);

                    temp.Add(temporary);
                }

                tires.Add(temp);
            }

            string engineInput = string.Empty;

            List<Engine> engines = new List<Engine>();

            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                double[] splittedInput = engineInput
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                int horsePower = (int)splittedInput[0];
                double cubicCapacity = splittedInput[1];

                Engine temp = new Engine(horsePower, cubicCapacity);

                engines.Add(temp);
            }

            string carsInput = string.Empty;

            List<Car> cars = new List<Car>();

            while ((carsInput = Console.ReadLine()) != "Show special")
            {
                string[] splittedInput = carsInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = splittedInput[0];
                string model = splittedInput[1];
                int year = int.Parse(splittedInput[2]);
                double fuelQuantity = double.Parse(splittedInput[3]);
                double fuelConsumption = double.Parse(splittedInput[4]);
                int engineIndex = int.Parse(splittedInput[5]);
                int tireIndex = int.Parse(splittedInput[6]);

                Tire[] tireArray = tires[tireIndex].ToArray();
                Engine engine = engines[engineIndex];

                Car car = new Car(make, 
                                   model, 
                                   year, 
                                   fuelQuantity, 
                                   fuelConsumption, 
                                   engine, 
                                   tireArray);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                double currentTirePressure = 0.0;

                foreach (var Tire in car.Tires)
                {
                    currentTirePressure += Tire.Pressure;
                }

                if (car.Year >= 2017 
                    && car.Engine.HorsePower >= 330 
                    && currentTirePressure >= 9 
                    && currentTirePressure <= 10)
                { 
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
