using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        public Polish()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= 7;

            Robots.Add(robot);
        }
    }
}
