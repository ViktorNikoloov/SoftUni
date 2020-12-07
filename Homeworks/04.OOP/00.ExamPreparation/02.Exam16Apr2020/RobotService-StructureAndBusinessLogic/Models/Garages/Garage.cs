using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int CapacityConstValue = 10;

        private int capacity;
        private IDictionary<string, IRobot> robots;

        public Garage()
        {
            robots = new Dictionary<string, IRobot>();
            capacity = CapacityConstValue;
        }

        public IReadOnlyDictionary<string, IRobot> Robots
            => (IReadOnlyDictionary<string, IRobot>)robots;

        public void Manufacture(IRobot robot)
        {
            if (robots.Count == capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (robots.Any(n=>n.Key == robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.Any(n => n.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot currRobot = null;

            foreach (var robot in robots)
            {
                if (robot.Key == robotName)
                {
                    currRobot = robot.Value;
                }
            }

            currRobot.Owner = ownerName;
            currRobot.IsBought = true;
            robots.Remove(robotName);
        }
    }
}
