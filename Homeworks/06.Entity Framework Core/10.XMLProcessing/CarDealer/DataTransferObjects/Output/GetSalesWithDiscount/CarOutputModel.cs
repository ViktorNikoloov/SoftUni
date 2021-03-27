using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Output.GetSalesWithDiscount
{
    [XmlType("car")]
    public class CarOutputModel
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
