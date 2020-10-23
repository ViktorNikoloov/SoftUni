using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> rabbits;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            rabbits = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count 
            => rabbits.Count;
        //{
        //    get
        //    {
        //        return rabbits.Count;
        //    }
        //}

        public void Add(Rabbit rabbit) //- adds an entity to the data if there is room for it
        {
            if (Count != Capacity)
            {
                rabbits.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name) //- removes a rabbit by given name, if such exists, and returns bool
        {
            Rabbit rabbit = null;
            bool isExist = rabbits.Any(x => x.Name == name);
            if (isExist)
            {
                rabbit = rabbits.FirstOrDefault(x => x.Name == name);
            }

            return rabbits.Remove(rabbit);
        }

        public void RemoveSpecies(string species) //- removes all rabbits by given species
            => rabbits.RemoveAll(x => x.Species == species);

        public Rabbit SellRabbit(string name) //- sell(set its Available property to false without removing it from the collection) the first rabbit with the given name, also return the rabbit
        {
            Rabbit rabbit = null;
            rabbit = rabbits.FirstOrDefault(x => x.Name == name);
            rabbit.Available = false;
            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species) //- sells(set their Available property to false without removing them from the collection) and returns all rabbits from that species as an array
        {
            List<Rabbit> soldRabbits = rabbits.Where(x => x.Species == species).ToList();
            soldRabbits.Select(x => x.Available = false).ToList();
            return soldRabbits.ToArray();
        }

        public string Report() //- returns a string in the following format, including only not sold rabbits
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {Name}:");
            foreach (var rabbit in rabbits)
            {
                if (rabbit.Available == true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}
