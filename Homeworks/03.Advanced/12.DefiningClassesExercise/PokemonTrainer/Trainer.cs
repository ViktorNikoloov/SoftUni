using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {
            Pokemons = new List<Pokemon>();
            NumberOfBadges = 0;
        }

        public Trainer(string name, Pokemon pokemon)
            : this()
        {
            Name = name;
            Pokemons.Add(pokemon);
        }
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

    }
}
