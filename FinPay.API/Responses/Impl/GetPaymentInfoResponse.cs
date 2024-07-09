using System.Text.Json.Serialization;

namespace FinPay.API.Responses.Impl;

public class GetPaymentInfoResponse : IResponse
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    
    [JsonPropertyName("shop_id")]
    public required int ShopId { get; set; }
    
    [JsonPropertyName("invoice_id")]
    public required int InvoiceId { get; set; }
    
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    
    [JsonPropertyName("pay_id")]
    public required int PaymentId { get; set; }
    
    [JsonPropertyName("method")]
    public required string PaymentMethod { get; set; }
    
    [JsonPropertyName("amount")]
    public required int Amount { get; set; }
    
    [JsonPropertyName("hold_expire")]
    public DateTime HoldExpiresAt { get; set; }
    
    [JsonPropertyName("hold_out")]
    public required int HoldOut { get; set; }
    
    [JsonPropertyName("status")]
    public required PaymentStatus PaymentStatus { get; set; }
    
    [JsonPropertyName("error")]
    public required string PaymentErrorType { get; set; }
    
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }
    
    public bool Success { get; set; }
    public string? ErrorCode { get; set; }
}