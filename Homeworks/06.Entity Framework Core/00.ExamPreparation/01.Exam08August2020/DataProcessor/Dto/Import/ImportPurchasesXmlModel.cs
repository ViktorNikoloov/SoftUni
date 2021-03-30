using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchasesXmlModel
    {
        [XmlAttribute("title")]
        [Required]
        public string GameName { get; set; }

        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        
        [XmlElement("Key")]
        [Required]
        [RegularExpression(@"[A-Z0-9]{4}\-[A-Z0-9]{4}\-[A-Z0-9]{4}$")]
        public string Key { get; set; }

        
        [XmlElement("Card")]
        [Required]
        [RegularExpression(@"([0-9]{4} *){4}")]
        public string CardNumber { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

    }
}
