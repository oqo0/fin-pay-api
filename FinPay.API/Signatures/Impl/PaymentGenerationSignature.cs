﻿using System.Globalization;
using FinPay.API.Utils;

namespace FinPay.API.Signatures.Impl;

public class PaymentGenerationSignature(
    int merchantId,
    int invoiceId,
    decimal paymentAmount,
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