using System;
using System.Collections.Generic;

namespace _08.Car_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string power = input[1];

                if (input.Length == 2)
                {
                    engines.Add(model, new Engine(model, power));
                }
                else if (input.Length == 3)
                {
                    bool isDisplacement = int.TryParse(input[2], out int displacement);

                    if (isDisplacement)
                    {
                        engines.Add(model, new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = input[2];

                        engines.Add(model, new Engine(model, power, efficiency));
                    }
                }
                else if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);

                    string efficiency = input[3];

                    engines.Add(model, new Engine(model, power, displacement, efficiency));
                }
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engine = input[1];

                if (input.Length == 2)
                {
                    cars.Add(new Car(model, engines[engine]));
                }
                else if (input.Length == 3)
                {
                    bool isWeight = int.TryParse(input[2], out int weight);

                    if (isWeight)
                    {
                        cars.Add(new Car(model, engines[engine], weight));
                    }
                    else
                    {
                        string color = input[2];

                        cars.Add(new Car(model, engines[engine], color));
                    }
                }
                else if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);

                    string color = input[3];

                    cars.Add(new Car(model, engines[engine], weight, color));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
