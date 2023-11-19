using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.Product;

public class ProductEditRequest
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("quantity")]
    public short Quantity { get; set; }
    
    [JsonPropertyName("remove")]
    public bool Remove { get; set; } = false;
}