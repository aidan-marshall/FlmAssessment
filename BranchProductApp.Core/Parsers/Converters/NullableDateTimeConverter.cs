using System.Text.Json.Serialization;
using System.Text.Json;


namespace BranchProductApp.Core.Parsers.Converters
{
    public class NullableDateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.String && DateTime.TryParse(reader.GetString(), out var date) ? date : (DateTime?)null;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString("yyyy/MM/dd"));
        }
    }
}
