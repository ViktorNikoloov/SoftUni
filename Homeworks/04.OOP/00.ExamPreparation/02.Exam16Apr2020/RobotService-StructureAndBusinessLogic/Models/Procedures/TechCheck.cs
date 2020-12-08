﻿using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public TechCheck()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChecked)
            {
                robot.Energy -= 8;
            }

            robot.Energy -= 8;
            robot.IsChecked = true;

            robots.Add(robot);
        }
    }
}
