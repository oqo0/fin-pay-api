using System.Text.Json.Serialization;

namespace FinPay.API.Responses.Impl;

public class CreatePaymentResponse : IResponse
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    #pragma warning disable CS9042
    // Members attributed with 'ObsoleteAttribute' should not be required unless the containing type is obsolete or all constructors are obsolete.
    [JsonPropertyName("payment_widget"), Obsolete]
    public string PaymentWidget { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("pay_id")]
    public string PayId { get; set; }

    public bool Success { get; set; } = true;
    public string? ErrorCode { get; set; }
}