namespace FinPay.API.Signatures.HashGenerators;

public interface IHashGenerator
{
    public string GetHash(string value);
}