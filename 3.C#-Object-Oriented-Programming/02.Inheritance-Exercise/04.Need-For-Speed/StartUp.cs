using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car(120, 80);

            Console.WriteLine($"Type: {car.GetType().Name}, " +
                $"FuelConsumption: {car.FuelConsumption}");



            RaceMotorcycle raceMotor = new RaceMotorcycle(500, 50);

            Console.WriteLine($"Type: {raceMotor.GetType().Name}, " +
                $"FuelConsumption: {raceMotor.FuelConsumption}");



            SportCar sportCar = new SportCar(550, 120);

            Console.WriteLine($"Type: {sportCar.GetType().Name}, " +
                $"FuelConsumption: {sportCar.FuelConsumption}");
        }
    }
}
