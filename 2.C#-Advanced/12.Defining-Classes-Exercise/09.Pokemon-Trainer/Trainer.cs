using System;
using System.Collections.Generic;
using System.Text;

namespace _09.Pokemon_Trainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> PokemonCollection { get; set; }

        public Trainer(string name, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.PokemonCollection = pokemons;
        }

        public void GetABadge()
        {
            this.NumberOfBadges++;
        }
    }
}
