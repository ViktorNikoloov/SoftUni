using Newtonsoft.Json;

namespace CarDealer.DTO.CarSalesWithDiscount
{
    public class CarInfo
    {
        [JsonProperty("car")]
        public CarDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public decimal Discount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

       [JsonProperty("priceWithDiscount")]
       public decimal PriceWithDiscount
       => Price - Discount;
    }
}
