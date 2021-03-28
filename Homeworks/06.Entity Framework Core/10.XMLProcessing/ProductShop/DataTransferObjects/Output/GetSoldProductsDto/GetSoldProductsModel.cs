using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output.GetSoldProductsDto
{
    [XmlType("User")]
    public class GetSoldProductsModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ProductModel[] SoldProducts { get; set; }
    }
}
