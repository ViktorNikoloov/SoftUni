using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name, string element, double health)
        {
            Name = name;
            Element = element;
            Health = health;
        }
        public string Name { get; set; }

        public string Element { get; set; }

        public double Health { get; set; }
    }
}
