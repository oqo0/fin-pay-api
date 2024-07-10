namespace FinPay.API.Exceptions;

public class FinPayException : Exception
{
    public FinPayException() {}
    public FinPayException(string? message) : base(message) {}
}