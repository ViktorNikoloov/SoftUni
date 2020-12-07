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
            robot.Happiness -= 7;

            base.DoService(robot, procedureTime);
        }
    }
}
