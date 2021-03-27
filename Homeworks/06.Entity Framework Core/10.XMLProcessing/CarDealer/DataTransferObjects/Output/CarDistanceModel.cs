using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Output
{
    [XmlType("car")]
    public class CarDistanceModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
