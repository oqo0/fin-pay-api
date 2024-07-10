namespace FinPay.API.Utils;

internal static class SignatureGenerator
{
    public static string Get(params string[] signatureItems)
    {
        return string.Join(':', signatureItems);
    }
}