namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto.Import_Employees;
    using TeisterMask.DataProcessor.ImportDto.ImportProjectsXml;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";
        private static object officersPrisionersDto;

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            const string root = "Projects";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectXmlModel[]), new XmlRootAttribute(root));

            var projectDtos = (ProjectXmlModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var projectsXmlOutput = new StringBuilder();
            var projects = new List<Project>();

            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    projectsXmlOutput.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? duedateProject;
                var openDateProject = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (string.IsNullOrEmpty(projectDto.DueDate))
                {
                    duedateProject = null;
                }
                else
                {
                    duedateProject = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = openDateProject,
                    DueDate = duedateProject,
                };

                foreach (var currentTask in projectDto.Tasks)
                {
                    if (!IsValid(currentTask))
                    {
                        projectsXmlOutput.AppendLine(ErrorMessage);
                        continue;
                    }

                    var dueDateTask = DateTime.ParseExact(currentTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var openDateTask = DateTime.ParseExact(currentTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (openDateTask < openDateProject || dueDateTask > duedateProject)
                    {
                        projectsXmlOutput.AppendLine(ErrorMessage);
                        continue;
                    }

                    var labelType = (LabelType)currentTask.LabelType;
                    var executionType = (ExecutionType)currentTask.ExecutionType;

                    var task = new Task
                    {
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        Name = currentTask.Name,
                        LabelType = labelType,
                        ExecutionType = executionType
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                projectsXmlOutput.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return projectsXmlOutput.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder employeesJsonOutput = new StringBuilder();
            List<Employee> employees = new List<Employee>();

            var jsonEmployees = JsonConvert.DeserializeObject<IEnumerable<EmployeesJsonModel>>(jsonString);

            foreach (var jsonEmployee in jsonEmployees)
            {
                if (IsValid(jsonEmployee))
                {
                    employeesJsonOutput.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee()
                {
                    Username = jsonEmployee.Username,
                    Email = jsonEmployee.Email,
                    Phone = jsonEmployee.Phone,
                };

                foreach (var jsonTask in jsonEmployee.Tasks.Distinct())
                {
                    var isTaskExist = context.Employees.FirstOrDefault(t => t.Id == jsonTask);

                    if (isTaskExist == null)
                    {
                        employeesJsonOutput.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        TaskId = jsonTask
                    });
                }

                employees.Add(employee);
                employeesJsonOutput.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return employeesJsonOutput.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}