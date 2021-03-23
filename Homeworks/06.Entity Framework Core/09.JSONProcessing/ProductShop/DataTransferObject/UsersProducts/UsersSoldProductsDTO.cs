using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProductShop.DataTransferObject.UsersProducts
{
    public class UsersSoldProductsDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public List<UserProducts> SoldProducts { get; set; }

    }
}
