﻿using System;
using System.Text;
using System.Collections.Generic;

using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {

        }

        protected List<IRobot> Robots { get; } = new List<IRobot>();

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            foreach (IRobot robot in Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {

            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;

        }

    }
}
