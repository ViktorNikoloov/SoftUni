using System.Collections.Generic;
using System.Text;
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

        protected IReadOnlyCollection<IRobot> Robots
        => (IReadOnlyCollection<IRobot>)robots;

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var robot in robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IRobot robot, int procedureTime);
    }
}
