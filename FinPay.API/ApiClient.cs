using System.Net.Http.Headers;
using System.Text.Json;
using FinPay.API.Exceptions;
using FinPay.API.Requests;
using FinPay.API.Responses;
using FinPay.API.Signatures;
using FinPay.API.Signatures.HashGenerators.Impl;

namespace FinPay.API;

public abstract class ApiClient(string apiUrl)
{
    private readonly HttpClient _httpClient = new();
    private readonly SignatureHashGenerator _signatureHashGenerator = new(new Md5HashGenerator());
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        Converters = { new RequestConverter() },
        WriteIndented = true
    };
    
    protected async Task<T> SendRequestAsync<T>(
        IRequest request, string apiUrlPath, ISignature signature, HttpMethod httpMethod)
        where T : IResponse
    {
        Authorize(request, signature);
        
        var responseString = await Queue(request, apiUrlPath, httpMethod);
        var responseObject = JsonSerializer.Deserialize<T>(responseString);

        HandleResponseError(responseObject);
        
        return responseObject!;
    }

    private void Authorize(IRequest request, ISignature signature)
    {
        request.Signature = _signatureHashGenerator.Get(signature);
    }
    
    private async Task<string> Queue(IRequest request, string apiUrlPath, HttpMethod httpMethod)
    {
        var messageContentJson = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        var message = new StringContent(messageContentJson);
        message.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var httpRequestMessage = new HttpRequestMessage(httpMethod, apiUrl + apiUrlPath);
        httpRequestMessage.Content = message;
        
        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
        string responseAsString = await httpResponseMessage.Content.ReadAsStringAsync();
        
        return responseAsString;
    }

    private static void HandleResponseError(IResponse? response)
    {
        if (response is null)
            throw new FinPayException("Не удалось обработать ответ.");
        if (!response.Success)
            throw new FinPayException(response.ErrorCode);
    }
}