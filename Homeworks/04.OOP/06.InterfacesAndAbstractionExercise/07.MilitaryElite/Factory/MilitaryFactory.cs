using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.Models;
using _07.MilitaryElite.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite.Factory
{
    public class MilitaryFactory
    {
        public MilitaryFactory()
        {

        }

        public ISoldier CreatSoldier(string[] soldierArgs, ICollection<ISoldier> privatesList)
        {
            string soldierType = soldierArgs[0];

            int id = int.Parse(soldierArgs[1]);
            string firstName = soldierArgs[2];
            string lastName = soldierArgs[3];

            ISoldier soldier = null;

            if (soldierType == "Private")
            {
                decimal salary = decimal.Parse(soldierArgs[4]);

                soldier = new Private(firstName, lastName, id, salary);
            }
            else if (soldierType == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(soldierArgs[4]);

                soldier = GreateGeneral(soldierArgs, id, firstName, lastName, salary, privatesList);
            }
            else if (soldierType == "Engineer")
            {
                decimal salary = decimal.Parse(soldierArgs[4]);
                string corps = soldierArgs[5];

                IEngineer engineer = CreateEngineer(soldierArgs, id, firstName, lastName, salary, corps);

                soldier = engineer;


            }
            else if (soldierType == "Commando")
            {
                decimal salary = decimal.Parse(soldierArgs[4]);
                string corps = soldierArgs[5];

                ICommando commando = CreateComando(soldierArgs, id, firstName, lastName, salary, corps);

                soldier = commando;


            }
            else if (soldierType == "Spy")
            {
                int codeNumber = int.Parse(soldierArgs[4]);

                soldier = new Spy(firstName, lastName, id, codeNumber);
            }

            return soldier;
        }

        private ILieutenantGeneral GreateGeneral(string[] soldierArgs, int id, string firstName, string lastName, decimal salary, ICollection<ISoldier> privatesList)
        {
            ILieutenantGeneral general = new LieutenantGeneral(firstName, lastName, id, salary);

            foreach (var iprivateId in soldierArgs.Skip(5))
            {
                ISoldier privateToAdd = privatesList.First(x => x.Id == int.Parse(iprivateId));

                general.AddPrivate(privateToAdd);
            }

            return general;
        }

        private static IEngineer CreateEngineer(string[] soldierArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            IEngineer engineer = new Engineer(firstName, lastName, id, salary, corps);

            string[] repairs = soldierArgs.Skip(6).ToArray();

            for (int i = 0; i < repairs.Length; i += 2)
            {
                string partName = repairs[i];
                int hoursWorked = int.Parse(repairs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                engineer.AddRepair(repair);
            }

            return engineer;
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
