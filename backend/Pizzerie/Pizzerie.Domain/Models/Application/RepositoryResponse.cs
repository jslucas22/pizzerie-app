using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.Application;

public class RepositoryResponse<T>
{
    [JsonPropertyName("success")] public bool Success { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }

    [JsonPropertyName("data")] public T Data { get; set; }

    public RepositoryResponse(bool success, T data, string message = "")
    {
        Success = success;
        Data = data;
        Message = message;
    }

    public static RepositoryResponse<T> CreateSuccessful(T data, string message = "Operation successful.")
        => new RepositoryResponse<T>(true, data, message);

    public static RepositoryResponse<T?> CreateFailure(string message = "Operation failed.") =>
        new RepositoryResponse<T?>(false, default(T), message);
}