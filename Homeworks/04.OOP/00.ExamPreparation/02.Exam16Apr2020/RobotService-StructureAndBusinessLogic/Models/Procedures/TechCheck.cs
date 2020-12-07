using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public TechCheck()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.IsChecked)
            {
                robot.Energy -= 8;
            }

            robot.Energy -= 8;
            robot.IsChecked = true;

            base.DoService(robot, procedureTime);
        }
    }
}
