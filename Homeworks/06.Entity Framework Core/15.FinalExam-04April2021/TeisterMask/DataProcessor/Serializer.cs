namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto.ExportMostBusiestEmployees;
    using TeisterMask.DataProcessor.ExportDto.ProjectsWithTheirTasksXml;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            const string root = "Projects";

            var xmlOutput = new StringWriter();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var ProjectsWithTheirTasks = context
                .Projects
                .Where(x => x.Tasks.Any())
                .ToArray() //becouse of SoftUni "Judge" system !
                .Select(x => new ProjectXmlModel()
                {
                    TasksCount = x.Tasks.Count(),
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(y => new TaskXmlModel()
                    {
                        Name = y.Name,
                        Label = y.LabelType.ToString()
                    })
                    .OrderBy(y => y.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var xmlSeriazlizer = new XmlSerializer(typeof(ProjectXmlModel[]), new XmlRootAttribute(root));
            xmlSeriazlizer.Serialize(xmlOutput, ProjectsWithTheirTasks, namespaces);

            return xmlOutput.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            const int EmployeesToBeTaken = 10;
            var employees = context
                            .Employees
                            .Where(x => x.EmployeesTasks.Any(y => y.Task.OpenDate >= date))
                            .Select(x => new EmployeesJsonModel()
                            {
                                Username = x.Username,
                                Tasks = x.EmployeesTasks
                                .Where(y => y.Task.OpenDate >= date)
                                .OrderByDescending(y => y.Task.DueDate)
                                .ThenBy(y => y.Task.Name)
                                .Select(t => new EmployeesTasksJson()
                                {
                                    TaskName = t.Task.Name,
                                    OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                    DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                    LabelType = t.Task.LabelType.ToString(),
                                    ExecutionType = t.Task.ExecutionType.ToString(),
                                })
                                .ToList()
                            })
                            .OrderByDescending(p => p.Tasks.Count())
                            .ThenBy(p => p.Username)
                            .Take(EmployeesToBeTaken)
                            .ToList();

            var jsonResult = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return jsonResult;
        }
    }
}