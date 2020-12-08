using System;
using System.Linq;

using RobotService.Core.Contracts;

using RobotService.Models.Garages.Contracts;
using RobotService.Models.Garages;

using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Procedures;

using RobotService.Models.Robots.Contracts;
using RobotService.Models.Robots;

using RobotService.Utilities.Messages;
using System.Collections.Generic;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;

        private IProcedure procedure;
        private IRobot robot;

        public Controller()
        {
            garage = new Garage();
        }

        //NOTE: For each command except for "Manufacture" and "History", you must check if a robot with that name exist in the garage. If it doesn't, throw an ArgumentException with the message "Robot {robot name} does not exist". 

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot currRobot = IsExist(robotName);
            
            procedure = new Chip();
            procedure.DoService(currRobot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot currRobot = IsExist(robotName);

            procedure = new TechCheck();
            procedure.DoService(currRobot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot currRobot = IsExist(robotName);

            procedure = new Rest();
            procedure.DoService(currRobot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot currRobot = IsExist(robotName);

            procedure = new Work();
            procedure.DoService(currRobot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot currRobot = IsExist(robotName);

            procedure = new Charge();
            procedure.DoService(currRobot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot currRobot = IsExist(robotName);

            procedure = new Polish();
            procedure.DoService(currRobot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot currRobot = IsExist(robotName);

            garage.Sell(robotName, ownerName);

            string result = currRobot.IsChipped == true ? $"{ownerName} bought robot with chip" : $"{ownerName} bought robot without chip";

            return result;
        }

        public string History(string procedureType)
        {
           return procedure.History();
        }

        private IRobot IsExist(string name)
        {
            if (!garage.Robots.Any(x => x.Key == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, name));
            }

            return garage.Robots[name];
        }

    }
}
