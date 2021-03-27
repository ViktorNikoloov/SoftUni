using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output
{
    [XmlType("Product")]
    public class ProductInRangeModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
