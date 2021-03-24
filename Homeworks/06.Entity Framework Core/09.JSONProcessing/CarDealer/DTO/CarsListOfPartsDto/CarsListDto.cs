using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO.CarsListOfPartsDto
{
    public class CarsListDto
    {
        [JsonProperty("car")]
        public CarsWithPartsListDto Car { get; set; }

        [JsonProperty("parts")]
        public List<PartsList> Parts { get; set; }
    }
}
