using System;
using System.Text;
using System.Linq;

using SoftUni.Data;
using SoftUni.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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

            //// 07.Employees and Projects
            //var employeesInPeriod = GetEmployeesInPeriod(softUniContext);
            //Console.WriteLine(employeesInPeriod);

            //// 08.Addresses by Town
            //var addressesByTown = GetAddressesByTown(softUniContext);
            //Console.WriteLine(addressesByTown);

            ////09. Employee 147
            //var employee147 = GetEmployee147(softUniContext);
            //Console.WriteLine(employee147);

            ////10.Departments With More Than 5 Employees
            //var departmentsWithMoreThan5Employees = GetDepartmentsWithMoreThan5Employees(softUniContext);
            //Console.WriteLine(departmentsWithMoreThan5Employees);

            //// 11.Find Latest 10 Projects
            //var getLatestProjects = GetLatestProjects(softUniContext);
            //Console.WriteLine(getLatestProjects);

            //// 12.Increase Salaries
            var increasedSalaries = IncreaseSalaries(softUniContext);
            Console.WriteLine(increasedSalaries);
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
                .Select(x => x.Address.AddressText)
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
            var employees = context.Employees
                .Include(ep => ep.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .Where(ep => ep.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.EmployeesProjects,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(x => new
                    {
                        ProjectName = x.Project.Name,
                        ProjectStartDate = x.Project.StartDate,
                        ProjectEndDate = x.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var hasEndDate = project.ProjectEndDate != null ? project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {hasEndDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        // 08.Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses.OrderByDescending(x => x.Employees.Count()).ThenBy(x => x.Town.Name).ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => new
                {
                    EmployeeCount = x.Employees.Count(),
                    TownName = x.Town.Name,
                    x.AddressText
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // 09.Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var theEmployee = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(x => new
                    {
                        ProjectName = x.Project.Name
                    }).OrderBy(x => x.ProjectName)

                }).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in theEmployee)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                foreach (var projects in employee.Projects)//.OrderBy(x=>x.ProjectName))
                {
                    sb.AppendLine(projects.ProjectName);
                }
            }

            return sb.ToString().TrimEnd();


            /*Second Solution*/
            //var theEmployee = context.Employees
            //   .Select(e => new
            //   {
            //       e.EmployeeId,
            //       e.FirstName,
            //       e.LastName,
            //       e.JobTitle,
            //       Projects = e.EmployeesProjects.Select(ep => ep.Project.Name)
            //       .OrderBy(ep => ep)
            //       .ToList()
            //       //Projects = x.EmployeesProjects.Select(x => new
            //       //{
            //       //    ProjectName = x.Project.Name
            //       //}).OrderBy(x=>x.ProjectName)
            //   })
            //   .SingleOrDefault(e => e.EmployeeId == 147);


            //StringBuilder sb = new StringBuilder();

            //    sb.
            //    AppendLine($"{theEmployee.FirstName} {theEmployee.LastName} - {theEmployee.JobTitle}");

            //    foreach (var projects in theEmployee.Projects)
            //    {
            //        sb.AppendLine(projects);
            //    }


            //return sb.ToString().TrimEnd();
        }

        //10.Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                    .Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        EmployeeJobTitle = e.JobTitle

                    }).OrderBy(e => e.EmployeeFirstName)
                      .ThenBy(e => e.EmployeeLastName)
                      .ToList()

                })
                 .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.EmployeeFirstName).ThenBy(e => e.EmployeeLastName))
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 11.Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(p => new
                {
                    Length = p.Name.Length,
                    ProjectName = p.Name,
                    ProjectDescribtion = p.Description,
                    ProjectStartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.ProjectName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var project in latestProjects)
            {
                sb
                    .AppendLine(project.ProjectName)
                    .AppendLine(project.ProjectDescribtion)
                    .AppendLine(project.ProjectStartDate);
            }

            return sb.ToString().TrimEnd();
        }

        //12.Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            context.Employees.Where(x => new[]
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            }.Contains(x.Department.Name))
            .ToList()
            .ForEach(x => x.Salary *= 1.12M);

            context.SaveChanges();

            var increasedSalary = context.Employees
                .Where(x => new[]
                {
                    "Engineering",
                    "Tool Design",
                    "Marketing",
                    "Information Services"
                 }.Contains(x.Department.Name))
                .Select(x => new
                {
                    EmployeeFirstName = x.FirstName,
                    EmployeeLastName = x.LastName,
                    EmployeeSalary = x.Salary
                })
                .OrderBy(x => x.EmployeeFirstName)
                .ThenBy(x => x.EmployeeLastName)
                .ToList();



            StringBuilder sb = new StringBuilder();
            foreach (var emp in increasedSalary)
            {
                sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} (${emp.EmployeeSalary:F2})");
            }

            return sb.ToString().TrimEnd();

        }

    }
}
