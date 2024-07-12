using System.Globalization;
using FinPay.API.Utils;

namespace FinPay.API.Signatures.Impl;

public class PaymentSignature(
    int merchantId,
    int invoiceId,
    int paymentAmount,
    string paymentMethodId,
    string merchantKey1)
    : ISignature
{
    public string GetParameters() => SignatureGenerator.Get(
        merchantId.ToString(),
        invoiceId.ToString(),
        paymentAmount.ToString(CultureInfo.CurrentCulture),
        paymentMethodId,
        merchantKey1);
}