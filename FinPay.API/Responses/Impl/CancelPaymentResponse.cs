namespace FinPay.API.Responses.Impl;

public class CancelPaymentResponse : IResponse
{
    public int DeletedPaymentId { get; set; }
    public bool Success { get; set; } = true;
    public string? ErrorCode { get; set; }
}