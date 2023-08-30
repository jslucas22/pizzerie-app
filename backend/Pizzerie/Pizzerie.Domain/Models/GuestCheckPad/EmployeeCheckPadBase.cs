using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.GuestCheckPad
{
    public class EmployeeCheckPadBase
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required")]
        [JsonPropertyName("id_employee")]
        public string IdEmployee { get; set; } = string.Empty;
    }
}
