using System.Text;
using System.Text.Json;
using FinPay.API.Exceptions;
using FinPay.API.Requests;
using FinPay.API.Responses;
using FinPay.API.Signatures;
using FinPay.API.Signatures.HashGenerators.Impl;

namespace FinPay.API;

public abstract class ApiClient(string apiUrl) : IDisposable
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri(apiUrl)
    };
    private readonly SignatureHashGenerator _signatureHashGenerator = new(
        new Md5HashGenerator());
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        Converters = { new RequestConverter() },
        WriteIndented = true
    };
    
    protected async Task<T> SendRequestAsync<T>(
        HttpMethod httpMethod, string apiUrlPath, IRequest request, ISignature authSignature)
        where T : IResponse
    {
        Authorize(request, authSignature);

        var responseString = await QueueAsync(request, apiUrlPath, httpMethod).ConfigureAwait(false);
        var responseObject = JsonSerializer.Deserialize<T>(responseString, _jsonSerializerOptions);

        HandleResponseError(responseObject);

        return responseObject!;
    }

    private void Authorize(IRequest request, ISignature signature)
    {
        request.Signature = _signatureHashGenerator.Get(signature);
    }
    
    private async Task<string> QueueAsync(IRequest request, string apiUrlPath, HttpMethod httpMethod)
    {
        var messageContentJson = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        var message = new StringContent(messageContentJson, Encoding.UTF8, "application/json");
        var httpRequestMessage = new HttpRequestMessage(httpMethod, apiUrlPath)
        {
            Content = message
        };
        
        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
        httpResponseMessage.EnsureSuccessStatusCode();
        
        return await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
    }

    private static void HandleResponseError(IResponse? response)
    {
        if (response is null)
            throw new FinPayException("Не удалось обработать ответ.");
        if (!response.Success)
            throw new FinPayException(response.ErrorCode);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}