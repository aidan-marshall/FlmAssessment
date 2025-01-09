using System.Text.Json.Serialization;
using System.Text.Json;

namespace BranchProductApp.Core.Parsers.Converters;

public class JsonWeightedItemConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value?.ToUpper() == "Y";
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value ? "Y" : "N");
    }
}
