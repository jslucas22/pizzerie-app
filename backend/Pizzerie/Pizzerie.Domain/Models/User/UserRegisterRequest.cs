using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.User;

public class UserRegisterRequest
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

    [JsonPropertyName("username")] public string Username { get; set; } = string.Empty;

    [JsonPropertyName("password")] public string Password { get; set; } = string.Empty;
    
    [JsonPropertyName("repeat_password")] public string RepeatPassword { get; set; } = string.Empty;

    [JsonPropertyName("level")] public short Level { get; set; }
}