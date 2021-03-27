using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Input
{
    [XmlType("User")]
    public class ImportUserModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
    }
}
