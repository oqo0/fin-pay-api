using FinPay.API.Requests.Impl;
using FinPay.API.Responses.Impl;
using FinPay.API.Signatures.Impl;

namespace FinPay.API;

/// <summary>
/// Клиент для работы с FinPay
/// </summary>
/// <param name="shopId">ID мерчанта</param>
/// <param name="key1">Ключ мерчанта №1</param>
/// <param name="key2">Ключ мерчанта №2</param>
public class FinPayApiClient(int shopId, string key1, string key2) : ApiClient(ApiUrl)
{
    private const string ApiUrl = "https://api.finpay.llc/payments";

    public async Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
    {
        var paymentCreationSignature = new PaymentCreationSignature(
            shopId,
            request.InvoiceId,
            request.Amount,
            request.PaymentMethod,
            key1);

        return await SendRequestAsync<CreatePaymentResponse>(
            HttpMethod.Post, "", request, paymentCreationSignature);
    }
}