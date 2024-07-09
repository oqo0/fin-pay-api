using System.Text.Json.Serialization;

namespace FinPay.API.Callbacks;

public interface ICallback
{
    [JsonPropertyName("error_code")]
    public string? ErrorCode { get; set; }
}