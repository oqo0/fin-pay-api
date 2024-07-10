using System.Text.Json.Serialization;

namespace FinPay.API.Responses.Impl;

public class GetPaymentInfoResponse : IResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("shop_id")]
    public int ShopId { get; set; }
    
    [JsonPropertyName("invoice_id")]
    public int InvoiceId { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("pay_id")]
    public int PaymentId { get; set; }
    
    [JsonPropertyName("method")]
    public string PaymentMethod { get; set; }
    
    [JsonPropertyName("amount")]
    public int Amount { get; set; }
    
    [JsonPropertyName("hold_expire")]
    public DateTime HoldExpiresAt { get; set; }
    
    [JsonPropertyName("hold_out")]
    public int HoldOut { get; set; }
    
    [JsonPropertyName("status")]
    public PaymentStatus PaymentStatus { get; set; }
    
    [JsonPropertyName("error")]
    public string PaymentErrorType { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    public bool Success { get; set; }
    public string? ErrorCode { get; set; }
}