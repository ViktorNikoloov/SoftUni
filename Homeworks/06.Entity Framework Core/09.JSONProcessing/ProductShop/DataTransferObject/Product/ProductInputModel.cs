﻿using Newtonsoft.Json;

namespace ProductShop.DataTransferObject.Product
{
    public class ProductInputModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int SellerId { get; set; }

        public int? BuyerId { get; set; }
    }
}
