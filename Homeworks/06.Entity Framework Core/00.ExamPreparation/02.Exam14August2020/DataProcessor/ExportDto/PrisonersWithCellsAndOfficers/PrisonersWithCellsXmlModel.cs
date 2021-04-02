using System.Collections.Generic;

namespace SoftJail.DataProcessor.ExportDto.PrisonersWithCellsAndOfficers
{
    public class PrisonersWithCellsXmlModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public IEnumerable<PrisonersOfficersXmlModel> Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }
}
