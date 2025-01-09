using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Parsers.Converters;
using BranchProductApp.Core.Products;
using BranchProductApp.Core.ProductBranchMappings;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BranchProductApp.Core.Parsers;

public static class JsonImporter
{
    private static JsonSerializerOptions BaseJsonOptions => new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true
    };

    public static List<T> ParseJson<T>(string filePath, JsonSerializerOptions options)
    {
        var jsonFile = File.ReadAllText(filePath);
        jsonFile = jsonFile.Trim();

        if (string.IsNullOrWhiteSpace(jsonFile))
        {
            throw new Exception("File is empty");
        }

        try
        {
            var result = JsonSerializer.Deserialize<List<T>>(jsonFile, options);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to parse JSON.");
            }
            return result;
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Failed to parse JSON.", ex);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static List<Branch> ParseBranchesJson(string filePath)
    {
        var options = BaseJsonOptions;
        options.Converters.Add(new NullableDateTimeConverter());
        options.Converters.Add(new TelephoneNumberConverter());

        return ParseJson<Branch>(filePath, options);
    }

    public static List<Product> ParseProductsJson(string filePath)
    {
        var options = BaseJsonOptions;
        options.Converters.Add(new JsonWeightedItemConverter());

        return ParseJson<Product>(filePath, options);
    }

    public static List<ProductBranchMapping> ParseMappingsJson(string filePath)
    {
        var options = BaseJsonOptions;

        return ParseJson<ProductBranchMapping>(filePath, options);
    }
}