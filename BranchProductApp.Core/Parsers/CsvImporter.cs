using System.Globalization;
using CsvHelper;
using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Products;
using BranchProductApp.Core.ProductBranchMappings;

namespace BranchProductApp.Core.Parsers;

public static class CsvImporter
{
    public static List<Branch> ParseCsvForBranches(string filePath)
    {
        var branches = new List<Branch>();
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<BranchMap>();
            branches = csv.GetRecords<Branch>().ToList();
        }
        return branches;
    }

    public static List<Product> ParseCsvForProducts(string filePath)
    {
        var products = new List<Product>();
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<ProductMap>();
            products = csv.GetRecords<Product>().ToList();
        }
        return products;
    }

    public static List<ProductBranchMapping> ParseCsvMappings(string filePath)
    {
        var mappings = new List<ProductBranchMapping>();
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<MappingMap>();
            mappings = csv.GetRecords<ProductBranchMapping>().ToList();
        }
        return mappings;
    }
}
