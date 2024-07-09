using System.Text.Json.Serialization;

namespace FinPay.API.Responses.Impl;

public class CreatePaymentResponse : IResponse
{
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    #pragma warning disable CS9042
    // Members attributed with 'ObsoleteAttribute' should not be required unless the containing type is obsolete or all constructors are obsolete.
    [JsonPropertyName("payment_widget"), Obsolete]
    public required string PaymentWidget { get; set; }
    
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    
    [JsonPropertyName("pay_id")]
    public required string PayId { get; set; }

    public bool Success { get; set; }
    public string? ErrorCode { get; set; }
}