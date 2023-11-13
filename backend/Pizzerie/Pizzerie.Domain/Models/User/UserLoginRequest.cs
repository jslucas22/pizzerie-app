using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.User;

public class UserLoginRequest
{
    [JsonPropertyName("username")] public string Username { get; set; } = string.Empty;

    [JsonPropertyName("password")] public string Password { get; set; } = string.Empty;
}