using System;
using System.Text;
using System.Linq;

using SoftUni.Data;
using SoftUni.Models;

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

            //// 03.Employees Full Information
            //var employeesFullInformation = GetEmployeesFullInformation(softUniContext);

            //Console.WriteLine(employeesFullInformation);

            //// 4.Employees with Salary Over 50 000
            //var employeesWithSalaryOver50000 = GetEmployeesWithSalaryOver50000(softUniContext);

            //Console.WriteLine(employeesWithSalaryOver50000);

            //// 05.GetEmployeesFromResearchAndDevelopment
            //var employeesFromResearchAndDevelopment = GetEmployeesFromResearchAndDevelopment(softUniContext);
            //Console.WriteLine(employeesFromResearchAndDevelopment);

            //// 06.Adding a New Address and Updating Employee
            //var addNewAddressToEmployee = AddNewAddressToEmployee(softUniContext);
            //Console.WriteLine(addNewAddressToEmployee);

            // 07.Employees and Projects
            var employeesInPeriod = AddNewAddressToEmployee(softUniContext);
            Console.WriteLine(employeesInPeriod);

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
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05.GetEmployeesFromResearchAndDevelopment
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var result = context.Employees.Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.Salary,
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 06.Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            /*First solution to save Nakov's new address*/
            //var newAddress = new Address
            //{
            //    AddressText = "Vitoshka 15",
            //    TownId = 4
            //};

            //context.Addresses.Add(newAddress);
            //context.SaveChanges();

            //var setAdressToNakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            //setAdressToNakov.AddressId = newAddress.AddressId;
            //context.SaveChanges();

            /*Second solution to save Nakov's new address*/
            var setAdressToNakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            setAdressToNakov.Address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.SaveChanges();


            var addresses = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x =>x.Address.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine(address);
            }
            
            return sb.ToString().TrimEnd();
        }

        // 07.Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

        }
    }
}
