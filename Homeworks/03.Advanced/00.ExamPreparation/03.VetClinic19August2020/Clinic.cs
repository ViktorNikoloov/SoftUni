using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new List<Pet>();
        }

        private List<Pet> pets;

        public int Capacity { get; set; }

        public int Count
            => pets.Count;

        //•	Method Add(Pet pet) – adds an entity to the data if there is an empty cell for the pet.
        public void Add(Pet pet)
        {
            if (pets.Count != Capacity)
            {
                pets.Add(pet);
            }

        }

        //•	Method Remove(string name) – removes the pet by given name, if such exists, and returns bool.
        public bool Remove(string name)
        {
            Pet pet = pets.FirstOrDefault(x => x.Name == name);
            return pets.Remove(pet);
        }

        //•	Method GetPet(string name, string owner) – returns the pet with the given name and owner or null if no such pet exists.
        public Pet GetPet(string name, string owner)
        => pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);


        //•	Method GetOldestPet() – returns the oldest Pet.
        public Pet GetOldestPet()
        {
            Pet theOldestPet = null;
            int age = 0;

            foreach (var pet in pets)
            {
                if (pet.Age > age)
                {
                    age = pet.Age;
                    theOldestPet = pet;
                }
            }

            return theOldestPet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
            

        }
        
    }
}
