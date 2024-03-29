﻿using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Input
{
    [XmlType("CategoryProduct")]
    public class ImportCategoriesProductsModel
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}
