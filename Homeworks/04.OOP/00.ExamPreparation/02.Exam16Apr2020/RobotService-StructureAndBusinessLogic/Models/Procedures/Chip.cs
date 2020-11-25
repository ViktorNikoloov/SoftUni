using System;
using System.Linq;

using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robots.Where(n=>n.KeyAny(x => x.Value.ProcedureTime < procedureTime))
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
        }
    }
}
