namespace FinPay.API.Exceptions;

internal class FinPayException : Exception
{
    public FinPayException() {}
    public FinPayException(string? message) : base(message) {}
}