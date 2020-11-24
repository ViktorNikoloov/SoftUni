using System.Collections.Generic;

using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int CapacityValue = 10;

        private int capacity;
        private IDictionary<string, IRobot> robots;

        protected Garage()
        {
            capacity = CapacityValue;
            robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots
            => (IReadOnlyDictionary<string, IRobot>)robots;

        public void Manufacture(IRobot robot)
        {
            throw new System.NotImplementedException();
        }

        public void Sell(string robotName, string ownerName)
        {
            throw new System.NotImplementedException();
        }
    }
}
