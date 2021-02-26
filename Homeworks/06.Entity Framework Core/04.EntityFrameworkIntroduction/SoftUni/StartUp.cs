using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            /*
            Install-Package Microsoft.EntityFrameworkCore.Tools –v 3.1.3
            Install-Package Microsoft.EntityFrameworkCore.SqlServer –v 3.1.3
            Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design
            */

            var softUniContext = new SoftUniContext();

            var result = GetEmployeesFullInformation(softUniContext);

            Console.WriteLine(result);
        }

        // 03.Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 4.Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {

        }
    }
}
