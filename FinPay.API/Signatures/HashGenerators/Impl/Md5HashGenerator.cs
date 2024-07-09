namespace FinPay.API.Signatures.HashGenerators.Impl;

public class Md5HashGenerator : IHashGenerator
{
    public string GetHash(string value)
    {
        var inputBytes = System.Text.Encoding.ASCII.GetBytes(value);
        var hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}