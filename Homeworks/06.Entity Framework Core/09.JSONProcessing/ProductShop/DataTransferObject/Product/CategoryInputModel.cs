using Newtonsoft.Json;

namespace ProductShop.DataTransferObject.Product
{
    class CategoryInputModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
