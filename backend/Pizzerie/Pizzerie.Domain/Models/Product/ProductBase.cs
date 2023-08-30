using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.Product
{
    public class ProductBase
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
    }
}
