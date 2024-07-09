using System.Text.Json.Serialization;

namespace FinPay.API.Requests;

public interface IRequest
{
    [JsonPropertyName("signature")]
    public string Signature { get; set; }
}