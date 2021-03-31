using System;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class UserPurchasesModel
    {
        public string Card { get; set; }

        public string Cvc { get; set; }

        public DateTime Date { get; set; }

        [XmlArray("Game")]
        public UserPurchasesGameModel[] Game { get; set; }

    }
}
