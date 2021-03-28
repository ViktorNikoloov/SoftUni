using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output.GetSoldProductsDto
{
    [XmlType("Product")]
    public class ProductModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}