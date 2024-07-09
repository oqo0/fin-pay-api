namespace FinPay.API.Signatures.Impl;

public class PaymentGenerationSignature(
    int merchantId,
    int invoiceId,
    decimal paymentAmount,
    string paymentMethodId,
    string merchantKey1)
    : ISignature
{
    public string GetParameters() => $"{merchantId}:{invoiceId}:{paymentAmount}:{paymentMethodId}:{merchantKey1}";
}