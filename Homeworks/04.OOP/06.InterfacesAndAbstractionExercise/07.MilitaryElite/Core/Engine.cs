using System.Collections.Generic;
using System.Linq;

using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.IO.Contracts;
using _07.MilitaryElite.Models;
using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Core
{
    class Engine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;
        ISoldier soldier = null;


        private Engine()
        {
            soldiers = new List<ISoldier>();
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
                string[] cmdArg = command.Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToArray();

                string soldierType = cmdArg[0];
                string id = cmdArg[1];
                string firstName = cmdArg[2];
                string lastName = cmdArg[3];


                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(cmdArg[4]);

                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArg[4]);

                    CreateGeneral(cmdArg, id, firstName, lastName, salary);

                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArg[4]);
                    string corps = cmdArg[5];

                    try
                    {
                        CreateEngineer(cmdArg, id, firstName, lastName, salary, corps);
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }

                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArg[4]);
                    string corps = cmdArg[5];

                    try
                    {
                        CreateCommando(cmdArg, id, firstName, lastName, salary, corps);
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }

                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArg[4]);

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldier = spy;

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

        private void CreateCommando(string[] cmdArg, string id, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            string[] missions = cmdArg.Skip(6).ToArray();
            for (int i = 0; i < missions.Length; i += 2)
            {
                string codeName = missions[i];
                string state = missions[i + 1];

                try
                {
                    IMission mission = new Mission(codeName, state);
                    commando.AddMission(mission);
                }
                catch (InvalidMissionStateException)
                {
                    continue;
                }

            }

            soldier = commando;
        }

        private void CreateGeneral(string[] cmdArg, string id, string firstName, string lastName, decimal salary)
        {
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var iprivateId in cmdArg.Skip(5))
            {
                ISoldier privateToAdd = soldiers.First(x => x.Id == iprivateId);
                general.AddPrivate(privateToAdd);
            }
            soldier = general;
        }

        private void CreateEngineer(string[] cmdArg, string id, string firstName, string lastName, decimal salary, string corps)
        {
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            string[] repairs = cmdArg.Skip(6).ToArray();
            for (int i = 0; i < repairs.Length; i += 2)
            {
                string partName = repairs[i];
                int hoursWorked = int.Parse(repairs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                engineer.AddRepair(repair);
            }

            soldier = engineer;
        }
    }
}
