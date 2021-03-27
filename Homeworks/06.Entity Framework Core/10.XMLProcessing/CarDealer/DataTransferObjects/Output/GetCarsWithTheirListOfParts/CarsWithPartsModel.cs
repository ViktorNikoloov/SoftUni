using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Output.GetCarsWithTheirListOfParts
{
    [XmlType("car")]
    public class CarsWithPartsModel
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartDTO[] Parts { get; set; }
    }
}
