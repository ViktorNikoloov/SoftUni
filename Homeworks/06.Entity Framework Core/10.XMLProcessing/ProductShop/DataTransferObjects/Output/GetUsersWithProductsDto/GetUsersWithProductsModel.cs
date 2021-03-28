using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output.GetUsersWithProductsDto
{
    [XmlType("User")]
    public class GetUsersWithProductsModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        /*[XmlElement("SoldProducts")]*/
        public SoldProductsModel SoldProducts{ get; set; }
    }
}
