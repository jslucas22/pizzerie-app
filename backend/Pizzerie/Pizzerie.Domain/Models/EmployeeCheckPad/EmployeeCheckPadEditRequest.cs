using System.Text.Json.Serialization;
using Pizzerie.Domain.Models.Product;

namespace Pizzerie.Domain.Models.EmployeeCheckPad
{
    public class EmployeeCheckPadEditRequest : EmployeeCheckPadBase
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("table_number")]
        public int? TableNumber { get; set; }

        [JsonPropertyName("client_name")]
        public string ClientName { get; set; } = string.Empty;

        [JsonPropertyName("products")]
        public List<ProductEditRequest>? Products { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("note")]
        public string Note { get; set; } = string.Empty;

        [JsonPropertyName("id_order_status")]
        public short? IdOrderStatus { get; set; }
    }
}