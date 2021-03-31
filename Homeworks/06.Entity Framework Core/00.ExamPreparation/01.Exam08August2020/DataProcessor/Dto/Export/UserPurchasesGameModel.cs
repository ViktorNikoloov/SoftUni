using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Game")]
    public class UserPurchasesGameModel
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
