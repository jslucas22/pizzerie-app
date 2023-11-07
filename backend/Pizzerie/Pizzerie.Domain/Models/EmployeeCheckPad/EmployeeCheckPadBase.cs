using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.EmployeeCheckPad
{
    public class EmployeeCheckPadBase
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [JsonPropertyName("id_employee")]
        public Guid IdEmployee { get; set; }
    }
}