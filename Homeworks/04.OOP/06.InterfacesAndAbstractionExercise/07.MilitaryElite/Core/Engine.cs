using System;
using System.Collections.Generic;
using System.Linq;
 
using _07.MilitaryElite.Core.Contracts;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.IO.Contracts;
using _07.MilitaryElite.Models;
using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;


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
                string[] cmdArg = command.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                string soldierType = cmdArg[0];
                int id = int.Parse(cmdArg[1]);
                string firstName = cmdArg[2];
                string lastName = cmdArg[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(cmdArg[4]);

                    soldier = new Private(firstName, lastName, id, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArg[4]);

                    soldier = GreateGeneral(cmdArg, id, firstName, lastName, salary);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArg[4]);
                    string corps = cmdArg[5];

                    try
                    {
                        IEngineer engineer = CreateEngineer(cmdArg, id, firstName, lastName, salary, corps);

                        soldier = engineer;
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
                        ICommando commando = CreateComando(cmdArg, id, firstName, lastName, salary, corps);

                        soldier = commando;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }

                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArg[4]);

                   soldier = new Spy(firstName, lastName, id, codeNumber);
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

        private static IEngineer CreateEngineer(string[] cmdArg, int id, string firstName, string lastName, decimal salary, string corps)
        {
            IEngineer engineer = new Engineer(firstName, lastName, id, salary, corps);

            string[] repairs = cmdArg.Skip(6).ToArray();

            for (int i = 0; i < repairs.Length; i += 2)
            {
                string partName = repairs[i];
                int hoursWorked = int.Parse(repairs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ILieutenantGeneral GreateGeneral(string[] cmdArg, int id, string firstName, string lastName, decimal salary)
        {
            ILieutenantGeneral general = new LieutenantGeneral(firstName, lastName, id, salary);

            foreach (var iprivateId in cmdArg.Skip(5))
            {
                ISoldier privateToAdd = soldiers.First(x => x.Id == int.Parse(iprivateId));
                 
                general.AddPrivate(privateToAdd);
            }

            return general;
        }

        private static ICommando CreateComando(string[] cmdArg, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(firstName, lastName, id, salary, corps);

            string[] missions = cmdArg.Skip(6).ToArray();

            for (int i = 0; i < missions.Length; i += 2)
            {

                try
                {
                    string codeName = missions[i];
                    string state = missions[i + 1];
                     
                    IMission mission = new Mission(codeName, state);
                     
                    commando.AddMission(mission);
                }
                catch (InvalidMissionStateException)
                {
                    continue;
                }

            }

            return commando;
        }

    }
}
