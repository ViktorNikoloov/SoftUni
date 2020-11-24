using System.Collections.Generic;

using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IRobot> robots;

        protected Procedure()
        {
            robots = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Robots
        => (IReadOnlyCollection<IRobot>)robots;

        public string History()
        {
            throw new System.NotImplementedException();
        }

        public abstract void DoService(IRobot robot, int procedureTime);
        

    }
}
