using System.Text.Json.Serialization;

namespace FinPay.API.Responses;

public interface IResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    [JsonPropertyName("code")]
    public string? ErrorCode { get; set; }
}