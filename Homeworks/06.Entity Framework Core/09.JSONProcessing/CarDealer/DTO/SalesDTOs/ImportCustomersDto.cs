﻿using Newtonsoft.Json;
using System;

namespace CarDealer.DTO.SalesDTOs
{
    public class ImportCustomersDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthDate")]

        public DateTime BirthDate { get; set; }

        [JsonProperty("isYoungDriver")]

        public bool IsYoungDriver { get; set; }
    }
}
