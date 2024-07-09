using System.Text.Json.Serialization;

namespace FinPay.API.Callbacks.Impl;

public class PaymentPaidCallback : ICallback
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    
    [JsonPropertyName("pay_id")]
    public required string PayId { get; set; }
    
    [JsonPropertyName("invoice_id")]
    public required int InvoiceId { get; set; }
    
    [JsonPropertyName("shop_id")]
    public required int ShopId { get; set; }
    
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    
    [JsonPropertyName("amount")]
    public required int Amount { get; set; }
    
    [JsonPropertyName("signature")]
    public required string Signature { get; set; }
    
    public string? ErrorCode { get; set; }
}