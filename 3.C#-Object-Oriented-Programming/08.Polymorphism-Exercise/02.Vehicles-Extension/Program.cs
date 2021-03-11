using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split();

            Car car = new Car(
                double.Parse(carInput[1]), 
                double.Parse(carInput[2]), 
                double.Parse(carInput[3]));

            string[] truckInput = Console.ReadLine().Split();

            Truck truck = new Truck(
                double.Parse(truckInput[1]), 
                double.Parse(truckInput[2]), 
                double.Parse(truckInput[3]));

            string[] busInput = Console.ReadLine().Split();

            Bus bus = new Bus(
                double.Parse(busInput[1]),
                double.Parse(busInput[2]),
                double.Parse(busInput[3]));

            int inputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputs; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(input[2]));
                }

                if (input[0] == "Drive")
                {
                    if (input[1] == "Car")
                    {
                        car.Drive(double.Parse(input[2]));
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Drive(double.Parse(input[2]));
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Drive(double.Parse(input[2]));
                    }
                }

                if (input[0] == "Refuel")
                {
                    if (input[1] == "Car")
                    {
                        car.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(input[2]));
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
