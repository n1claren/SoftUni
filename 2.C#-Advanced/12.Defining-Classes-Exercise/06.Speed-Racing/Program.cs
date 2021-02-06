using System;
using System.Collections.Generic;

namespace _06.Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < inputs; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

                cars.Add(model, car);
            }

            string action = string.Empty;

            while ((action = Console.ReadLine()) != "End")
            {
                string[] actions = action.Split();

                string model = actions[1];
                double distance = double.Parse(actions[2]);

                cars[model].Drive(distance);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
            }
        }
    }
}
