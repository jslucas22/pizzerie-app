using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.Product
{
    public class ProductBase
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("quantity")]
        public short Quantity { get; set; }
        
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}