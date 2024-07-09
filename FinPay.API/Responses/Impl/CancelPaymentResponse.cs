namespace FinPay.API.Responses.Impl;

public class CancelPaymentResponse : IResponse
{
    public required int DeletedPaymentId { get; set; }
    public bool Success { get; set; }
    public string? ErrorCode { get; set; }
}