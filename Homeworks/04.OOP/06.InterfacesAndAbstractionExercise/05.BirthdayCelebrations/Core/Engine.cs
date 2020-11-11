using System.Collections.Generic;
using System.Linq;

using _05.BirthdayCelebrations;
using _05.BirthdayCelebrations.Core;
using _05.BirthdayCelebrations.IO.Contracts;
using _05.BirthdayCelebrations.Models.Contracts;

namespace _04.BorderControl.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        ICollection<IBirthable> identities;
        ICollection<IBirthable> matchedDate;

        private Engine()
        {
            identities = new List<IBirthable>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split();

                if (cmdArg[0] == "Citizen")
                {
                    string name = cmdArg[1];
                    int age = int.Parse(cmdArg[2]);
                    string id = cmdArg[3];
                    string birthdate = cmdArg[4];

                    ICitizen citizen = new Citizen(name, age, id, birthdate);
                    identities.Add(citizen);
                }
                else if(cmdArg[0] == "Pet")
                {
                    string name = cmdArg[1];
                    string birthdate = cmdArg[2];

                    Pet pet = new Pet(name, birthdate);
                    identities.Add(pet);
                }

            }

            string yearOfBirthdate = reader.ReadLine();

            matchedDate = identities
                .Where(c => c.Birthdate
                .EndsWith(yearOfBirthdate))
                .ToList();

            foreach (var birthdate in matchedDate)
            {
                writer.WriteLine(birthdate.ToString());
            }
        }
    }
}
