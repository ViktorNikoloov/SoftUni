namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto.PrisonersWithCellsAndOfficers;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var allPrisonersCellsAndOfficerByIds = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new PrisonersWithCellsXmlModel()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(o => new PrisonersOfficersXmlModel()
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = decimal
                        .Parse(p.PrisonerOfficers.Sum(o => o.Officer.Salary)
                        .ToString("F2"))
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(allPrisonersCellsAndOfficerByIds, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            return "TODO";

        }
    }
}