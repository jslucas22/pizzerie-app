using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.User;

public class UserRequest
{
    [JsonPropertyName("username")] public string Username { get; set; } = string.Empty;

    [JsonPropertyName("password")] public string Password { get; set; } = string.Empty;
}