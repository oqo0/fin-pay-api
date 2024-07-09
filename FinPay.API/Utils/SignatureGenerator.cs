using System.Text;

namespace FinPay.API.Utils;

public static class SignatureGenerator
{
    public static string Get(params string[] signatureItems)
    {
        return string.Join(':', signatureItems);
    }
}