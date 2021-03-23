using Newtonsoft.Json;

namespace ProductShop.DataTransferObject.ExportUserAndProducts
{
    public class ProductDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
