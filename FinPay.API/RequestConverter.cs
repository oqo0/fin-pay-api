using System.Text.Json;
using System.Text.Json.Serialization;
using FinPay.API.Requests;

namespace FinPay.API;

public class RequestConverter : JsonConverter<IRequest>
{
    public override IRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented.");
    }

    public override void Write(Utf8JsonWriter writer, IRequest value, JsonSerializerOptions options)
    {
        var type = value.GetType();
        JsonSerializer.Serialize(writer, value, type, options);
    }
}
