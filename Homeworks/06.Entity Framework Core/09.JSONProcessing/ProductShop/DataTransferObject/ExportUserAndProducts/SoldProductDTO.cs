using System.Collections.Generic;

using Newtonsoft.Json;

namespace ProductShop.DataTransferObject.ExportUserAndProducts
{
    public class SoldProductDTO
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("products")]
        public List<ProductDTO> Products { get; set; }
    }
}
