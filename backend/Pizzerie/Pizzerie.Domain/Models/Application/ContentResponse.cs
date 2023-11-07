using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.Application
{
    public class ContentResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}
