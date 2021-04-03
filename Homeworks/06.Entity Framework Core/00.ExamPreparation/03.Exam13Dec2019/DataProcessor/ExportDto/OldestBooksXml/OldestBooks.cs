using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto.OldestBooksXml
{
    [XmlType("Book")]
    public class OldestBooks
    {
        [XmlAttribute("Pages")]
        public string Pages { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }
    }
}
