using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Output.GetUsersWithProductsDto
{
    [XmlType("Users")]
    public class UserRootDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public GetUsersWithProductsModel[] Users { get; set; }
    }
}
