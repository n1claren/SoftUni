using System;
using System.Collections.Generic;

namespace _04.Cities_By_Continent_And_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            int inputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputs; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }    

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"{country.Key} -> ");
                    Console.WriteLine(string.Join(", ", country.Value));
                }
            }
        }
    }
}
