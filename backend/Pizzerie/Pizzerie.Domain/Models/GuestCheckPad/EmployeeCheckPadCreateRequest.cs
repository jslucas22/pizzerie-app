using Pizzerie.Domain.Models.Product;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.GuestCheckPad
{
    public class EmployeeCheckPadCreateRequest : EmployeeCheckPadBase
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [JsonPropertyName("client_name")]
        public string ClientName { get; set; } = string.Empty;

        [JsonPropertyName("products")]
        public List<ProductBase>? Products { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [JsonPropertyName("creation_date")]
        public DateTime Creation { get; set; }

        public EmployeeCheckPadCreateRequest()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
