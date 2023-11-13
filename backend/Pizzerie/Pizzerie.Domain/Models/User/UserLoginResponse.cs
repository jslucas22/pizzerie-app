using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.User;

public class UserLoginResponse
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

    [JsonPropertyName("username")] public string Username { get; set; } = string.Empty;

    [JsonPropertyName("password")] public string Password { get; set; } = string.Empty;

    [JsonPropertyName("level")] public string Level { get; set; } = string.Empty;

    [JsonPropertyName("created_at")] public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("updated_at")] public DateTimeOffset UpdatedAt { get; set; }

    public void ClearPassword()
    {
        Password = string.Empty;
    }
}