using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output
{
    [XmlType("Category")]
    public class CategoriesProductsCountModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }

    }
}
