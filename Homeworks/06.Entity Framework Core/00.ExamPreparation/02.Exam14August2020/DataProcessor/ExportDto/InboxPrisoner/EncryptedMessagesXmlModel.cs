using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto.InboxPrisoner
{
    [XmlType("Message")]
    public class EncryptedMessagesXmlModel
    {
        public string Description { get; set; }
    }
}
