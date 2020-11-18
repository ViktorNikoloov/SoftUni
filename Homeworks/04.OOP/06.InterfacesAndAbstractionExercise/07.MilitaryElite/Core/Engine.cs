using System;
using System.Collections.Generic;
using System.Linq;
 
using _07.MilitaryElite.Core.Contracts;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.Factory;
using _07.MilitaryElite.IO.Contracts;
using _07.MilitaryElite.Models;
using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ISoldier soldier;

        private ICollection<ISoldier> soldiers;
        private readonly MilitaryFactory militaryFactory;

        private Engine()
        {
            soldiers = new List<ISoldier>();
            militaryFactory = new MilitaryFactory();
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
                string[] cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    soldier = militaryFactory.CreatSoldier(cmdArg, soldiers);

                }
                catch (InvalidCorpsException ice)
                {

                    continue;
                }
               

                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }

            }

            foreach (var soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }

        }
    }
}
