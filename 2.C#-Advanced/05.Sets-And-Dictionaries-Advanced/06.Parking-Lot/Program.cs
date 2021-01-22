using System;
using System.Collections.Generic;

namespace _06.Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string licencePlate = string.Empty;

            while ((licencePlate = Console.ReadLine()) != "END")
            {
                string[] reg = licencePlate.Split(", ");

                if (reg[0] == "IN")
                {
                    cars.Add(reg[1]);
                }

                else if (reg[0] == "OUT")
                {
                    cars.Remove(reg[1]);
                }    
            }

            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
