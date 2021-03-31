using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserModel
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public UserPurchasesModel[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }

    }
}
