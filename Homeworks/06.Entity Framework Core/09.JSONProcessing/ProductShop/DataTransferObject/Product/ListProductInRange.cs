using Newtonsoft.Json;

namespace ProductShop.DataTransferObject.Product
{
    public class ListProductInRange
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]

        public decimal Price { get; set; }

        [JsonProperty("seller")]

        public string SellerName { get; set; }
    }
}
