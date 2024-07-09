namespace FinPay.API.Signatures.Impl;

public class SuccessCallbackSignature(
    string merchantKey2,
    int paymentId,
    string paymentGenerationSignatureHash)
    : ISignature
{
    public string GetParameters() => $"{merchantKey2}:{paymentId}:{paymentGenerationSignatureHash}";
}