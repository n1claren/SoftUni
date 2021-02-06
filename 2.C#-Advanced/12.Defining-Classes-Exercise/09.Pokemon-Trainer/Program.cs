using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] splitted = input.Split();

                string trainerName = splitted[0];
                string pokemonName = splitted[1];
                string pokemonElement = splitted[2];
                int pokemonHealth = int.Parse(splitted[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName, new List<Pokemon>{ pokemon }));
                }
                else
                {
                    trainers[trainerName].PokemonCollection.Add(pokemon);
                }
            }

            string element = string.Empty;

            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    bool hasPokemonWithGivenElement = false;

                    foreach (var pokemon in trainer.Value.PokemonCollection)
                    {
                        if (pokemon.Element == element && pokemon.Health > 0)
                        {
                            hasPokemonWithGivenElement = true;
                        }
                    }

                    if (hasPokemonWithGivenElement)
                    {
                        trainer.Value.GetABadge();
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.PokemonCollection)
                        {
                            pokemon.ReduceHealth();
                        }
                    }
                }
            }

            trainers = trainers
                .OrderByDescending(n => n.Value.NumberOfBadges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var trainer in trainers)
            {
                int pokemonCount = 0;

                foreach (var pokemon in trainer.Value.PokemonCollection)
                {
                    if (pokemon.Health > 0)
                    {
                        pokemonCount++;
                    }
                }

                Console.WriteLine($"{trainer.Key} " +
                    $"{trainer.Value.NumberOfBadges} " +
                    $"{pokemonCount}");
            }
        }
    }
}
