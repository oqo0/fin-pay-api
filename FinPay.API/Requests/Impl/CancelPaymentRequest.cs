using System.Text.Json.Serialization;

namespace FinPay.API.Requests.Impl;

public class CancelPaymentRequest
{
    [JsonPropertyName("id")]
    public required int PaymentId { get; set; }

    [JsonPropertyName("signature")]
    public required string Signature { get; set; }
}