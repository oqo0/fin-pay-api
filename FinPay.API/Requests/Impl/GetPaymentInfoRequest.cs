namespace FinPay.API.Requests.Impl;

public class GetPaymentInfoRequest : IRequest
{
    public required string Signature { get; set; }
}