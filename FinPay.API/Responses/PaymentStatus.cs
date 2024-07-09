using System.Text.Json.Serialization;

namespace FinPay.API.Responses;

public enum PaymentStatus
{
    [JsonPropertyName("created")]
    Created,
    [JsonPropertyName("pending")]
    Pending,
    [JsonPropertyName("processing")]
    Processing,
    [JsonPropertyName("paid")]
    Paid,
    [JsonPropertyName("failed")]
    Failed
}