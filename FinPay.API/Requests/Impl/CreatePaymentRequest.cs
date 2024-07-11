using System.Text.Json.Serialization;

namespace FinPay.API.Requests.Impl;

public class CreatePaymentRequest : IRequest
{
    [JsonPropertyName("shop_id")]
    public int ShopId { get; set; }
    
    [JsonPropertyName("invoice_id")]
    public required int InvoiceId { get; set; }
    
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    
    [JsonPropertyName("amount")]
    public required int Amount { get; set; }
    
    [JsonPropertyName("method")]
    public required string PaymentMethod { get; set; }
    
    [JsonPropertyName("country")]
    public required string CountryCode { get; set; }
    
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("signature")]
    public string Signature { get; set; }
}