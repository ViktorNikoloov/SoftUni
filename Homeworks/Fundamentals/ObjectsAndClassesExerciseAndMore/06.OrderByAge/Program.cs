using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Profil> profils = new List<Profil>();

            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                Profil profil = new Profil(command[0], command[1], int.Parse(command[2]));
                profils.Add(profil);

                command = Console.ReadLine().Split();
            }

            List<Profil> ordered = profils.OrderBy(x => x.Age).ToList();
            
            foreach (var item in ordered)
            {
                Console.WriteLine(item.ToString());
              
            }

        }
    }

    public class Profil
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public List<string> profiles;

        public Profil(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
            profiles = new List<string>();
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}
