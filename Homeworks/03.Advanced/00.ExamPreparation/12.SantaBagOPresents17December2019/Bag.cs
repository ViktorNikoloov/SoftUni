using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            presents = new List<Present>();
        }

        private List<Present> presents;
        public int Count
            => presents.Count;

        public string Color { get; set; }

        public int Capacity { get; set; }

        public void Add(Present present) // adds an entity to the data if there is room for it
        {
            if (presents.Count < Capacity)
            {
                presents.Add(present);
            }

        }

        public bool Remove(string name) // removes a present by given name, if such exists, and returns bool
        {

            Present present = presents.FirstOrDefault(x => x.Name == name);
            return presents.Remove(present);
        }

        public Present GetHeaviestPresent() //- returns the heaviest present
            => presents.OrderByDescending(x => x.Weight).First();
        //{



        //Present maxWeightPresent = null;
        //double maxWeight = 0;
        //foreach (var present in presents)
        //{
        //    if (present.Weight > maxWeight)
        //    {
        //        maxWeight = present.Weight;
        //        maxWeightPresent = present;
        //    }
        //}
        //return maxWeightPresent;
        //}

        public Present GetPresent(string name) //returns the present with the given name
        => presents.FirstOrDefault(x => x.Name == name);

        public string Report() //returns a string in the following format(print the presents in order of appearance)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} bag contains:");
            foreach (var present in presents)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
