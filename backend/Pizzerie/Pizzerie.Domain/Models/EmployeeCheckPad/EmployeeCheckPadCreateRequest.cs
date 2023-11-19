using System.Text.Json.Serialization;
using Pizzerie.Domain.Models.Product;

namespace Pizzerie.Domain.Models.EmployeeCheckPad
{
    public class EmployeeCheckPadCreateRequest : EmployeeCheckPadBase
    {
        [JsonPropertyName("table_number")]
        public short TableNumber { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; } = string.Empty;

        [JsonPropertyName("client_name")]
        public string ClientName { get; set; } = string.Empty;

        [JsonPropertyName("products")] public List<ProductBase>? Products { get; set; }
    }
}