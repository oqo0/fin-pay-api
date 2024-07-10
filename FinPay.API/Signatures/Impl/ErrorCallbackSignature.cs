using FinPay.API.Utils;

namespace FinPay.API.Signatures.Impl;

internal class ErrorCallbackSignature(
    string merchantKey2,
    int paymentId,
    string paymentGenerationSignatureHash)
    : ISignature
{
    public string GetParameters() => SignatureGenerator.Get(
        merchantKey2,
        paymentId.ToString(),
        paymentGenerationSignatureHash);
}