using System;
using System.Linq;
using _01.DatabaseFirst.Models;

namespace _01.DatabaseFirst
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            var townsCount = db.Towns.Count();
            db.Towns.Add(new Town { Name = "Pernik" });
            db.SaveChanges();
            townsCount = db.Towns.Count();


            var result = db.Employees.Count();
            Console.WriteLine(result);

            var employees = db.Employees
                .Where(x => x.FirstName.StartsWith("V"))
                .OrderByDescending(x => x.Salary)
                .Select(x => new { FullName = x.FirstName + " " + x.LastName, x.Salary })
                .ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Full Name: {employee.FullName} => Salary: {employee.Salary}");
            }

            var Departments = db.Employees
                .GroupBy(x => x.Department.Name)
                .Select(x => new { GroupName = x.Key, EmployeesCount = x.Count() }).ToList();
            foreach (var department in Departments)
            {
                Console.WriteLine($"Department: {department.GroupName} => Count: {department.EmployeesCount}");
            }
        }
    }
}
