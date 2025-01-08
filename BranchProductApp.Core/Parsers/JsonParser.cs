using BranchProductApp.Core.Branches;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BranchProductApp.Core.Parsers
{
    public static class JsonParser
    {
        public static List<Branch> ParseJson(string filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            jsonFile = filePath.Trim();

            if (jsonFile == null)
            {
                throw new Exception("File is empty");
            }

            var options = new JsonSerializerOptions
            {
                Converters = { new NullableDateTimeConverter(), new TelephoneNumberConverter() },
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true
            };

            try
            {
                return JsonSerializer.Deserialize<List<Branch>>(jsonFile, options);
            }
            catch (JsonException ex)
            {
                // Handle or log the exception as needed
                throw new InvalidOperationException("Failed to parse JSON.", ex);
            }
        }
    }

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

    public class TelephoneNumberConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString(),
                JsonTokenType.Number => reader.GetInt64().ToString(),
                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
