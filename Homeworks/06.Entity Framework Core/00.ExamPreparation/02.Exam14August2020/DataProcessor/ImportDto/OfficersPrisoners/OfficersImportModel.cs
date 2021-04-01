using SoftJail.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto.OfficersPrisoners
{
    [XmlType("Officer")]
    public class OfficersImportModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [Range(0, double.MaxValue)]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }

        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonersImportModel[] Prisoners { get; set; }
    }
}
