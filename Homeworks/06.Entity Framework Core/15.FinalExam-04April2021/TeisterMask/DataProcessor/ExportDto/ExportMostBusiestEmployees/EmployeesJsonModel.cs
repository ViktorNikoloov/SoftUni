using System.Collections.Generic;

namespace TeisterMask.DataProcessor.ExportDto.ExportMostBusiestEmployees
{
    public class EmployeesJsonModel
    {
        public string Username { get; set; }

        public IEnumerable<EmployeesTasksJson> Tasks { get; set; }
    }
}
