using System.Text.Json.Serialization;

namespace FinPay.API.Requests.Impl;

public class CancelPaymentRequest : IRequest
{
    [JsonPropertyName("id")]
    public required int PaymentId { get; set; }

    [JsonPropertyName("signature")]
    public string Signature { get; set; }
}