using Newtonsoft.Json;

namespace ProductShop.DataTransferObject.Product
{
    public class UserInputModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]

        public string LastName { get; set; }

        [JsonProperty("age")]

        public int? Age { get; set; }
    }
}
