namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Department> departments = new List<Department>();

            var jsonDepartments = JsonConvert.DeserializeObject<IEnumerable<DepartmentsImportModel>>(jsonString);

            foreach (var jsonDepartment in jsonDepartments)
            {
                if (!IsValid(jsonDepartment) || !jsonDepartment.Cells.All(IsValid) || !jsonDepartment.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var departmentCells = new Department()
                {
                    Name = jsonDepartment.Name,
                    Cells = jsonDepartment.Cells.Select(c => new Cell
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow
                    }).ToList()
                };

                departments.Add(departmentCells);

                sb.AppendLine($"Imported {jsonDepartment.Name} with {jsonDepartment.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            return "TODO";
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            return "TODO";

        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}