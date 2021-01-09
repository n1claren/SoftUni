using System;
using System.Collections.Generic;

namespace _05.SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "register")
                {
                    if (parking.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[input[1]]}");
                    }
                    else
                    {
                        parking.Add(input[1], input[2]);
                        Console.WriteLine($"{input[1]} registered {input[2]} successfully");
                    }
                }

                if (input[0] == "unregister")
                {
                    if (parking.ContainsKey(input[1]))
                    {
                        parking.Remove(input[1]);
                        Console.WriteLine($"{input[1]} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {input[1]} not found");
                    }
                }
            }

            foreach (var spot in parking)
            {
                Console.WriteLine($"{spot.Key} => {spot.Value}");
            }
        }
    }
}