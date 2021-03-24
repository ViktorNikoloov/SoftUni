using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO.CarsListOfPartsDto
{
    public class CarsWithPartsListDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

    }
}