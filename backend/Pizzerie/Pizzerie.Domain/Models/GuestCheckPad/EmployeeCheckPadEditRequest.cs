using Pizzerie.Domain.Models.Product;
using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.GuestCheckPad
{
    public class EmployeeCheckPadEditRequest : EmployeeCheckPadBase
    {
        [JsonPropertyName("products")]
        public List<ProductBase>? Products { get; set; }

        [JsonPropertyName("last_change_date")]
        public DateTime LastChange { get; set; }
    }
}
