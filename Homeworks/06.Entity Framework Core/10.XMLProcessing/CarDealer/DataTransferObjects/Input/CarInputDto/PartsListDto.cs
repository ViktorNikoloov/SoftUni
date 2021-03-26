using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Input.CarInputDto
{
    [XmlType("partId")]
    public class PartsListDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
