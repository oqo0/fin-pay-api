using FinPay.API.Signatures.HashGenerators;

namespace FinPay.API.Signatures;

public class SignatureHashGenerator(IHashGenerator hashGenerator)
{
    public string Get(ISignature signature)
    {
        return hashGenerator.GetHash(signature.GetParameters());
    }
}