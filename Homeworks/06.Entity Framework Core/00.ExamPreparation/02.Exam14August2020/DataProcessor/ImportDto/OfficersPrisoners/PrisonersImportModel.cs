using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto.OfficersPrisoners
{
    [XmlType("Prisoner")]
    public class PrisonersImportModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

    }
}
