using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Parsers.Converters;
using BranchProductApp.Core.Products;
using BranchProductApp.Core.ProductBranchMappings;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BranchProductApp.Core.Parsers;

public static class JsonParser
{
    public static List<Branch> ParseBranchesJson(string filePath)
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
            throw new InvalidOperationException("Failed to parse JSON.", ex);
        }
    }

    public static List<Product> ParseProductsJson(string filePath)
    {
        var jsonFile = File.ReadAllText(filePath);
        jsonFile = jsonFile.Trim();

        if (jsonFile == null)
        {
            throw new Exception("File is empty");
        }

        var options = new JsonSerializerOptions
        {
            Converters = {new JsonWeightedItemConverter()},
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true
        };

        try
        {
            return JsonSerializer.Deserialize<List<Product>>(jsonFile, options);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Failed to parse JSON.", ex);
        }
    }

    public static List<ProductBranchMapping> ParseMappingsJson(string filePath)
    {
        var jsonFile = File.ReadAllText(filePath);
        jsonFile = jsonFile.Trim();

        if (jsonFile == null)
        {
            throw new Exception("File is empty");
        }

        var options = new JsonSerializerOptions
        {
            Converters = { },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true
        };

        try
        {
            return JsonSerializer.Deserialize<List<ProductBranchMapping>>(jsonFile, options);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Failed to parse JSON.", ex);
        }
    }
}