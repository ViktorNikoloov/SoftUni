using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Output
{
    [XmlType("suplier")]
    public class CarLocalSuppliers
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
