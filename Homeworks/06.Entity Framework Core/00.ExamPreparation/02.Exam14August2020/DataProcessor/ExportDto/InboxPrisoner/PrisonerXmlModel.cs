using System;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto.InboxPrisoner
{
    [XmlType("Prisoner")]
    public class PrisonerXmlModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public EncryptedMessagesXmlModel[] EncryptedMessages { get; set; }
    }
}
