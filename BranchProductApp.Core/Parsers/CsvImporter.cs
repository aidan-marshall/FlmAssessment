using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Products;
using BranchProductApp.Core.ProductBranchMappings;
using BranchProductApp.Core.Parsers.Converters;

namespace BranchProductApp.Core.Parsers
{
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

        internal sealed class MappingMap : ClassMap<ProductBranchMapping>
        {
            public MappingMap()
            {
                Map(m => m.BranchId).Name("BranchID");
                Map(m => m.ProductId).Name("ProductID");
                Map(m => m.Branch).Ignore();
                Map(m => m.Product).Ignore();
            }
        }

        internal sealed class BranchMap : ClassMap<Branch>
        {
            public BranchMap()
            {
                Map(m => m.Id).Name("ID");
                Map(m => m.Name).Name("Name");
                Map(m => m.TelephoneNumber).Name("TelephoneNumber");
                Map(m => m.OpenDate).Name("OpenDate").TypeConverter<CustomDateTimeConverter>();
                Map(m => m.ProductBranchMappings).Ignore();
            }
        }

        internal sealed class ProductMap : ClassMap<Product>
        {
            public ProductMap()
            {
                Map(m => m.Id).Name("ID");
                Map(m => m.Name).Name("Name");
                Map(m => m.WeightedItem).Name("WeightedItem").TypeConverter<YesNoBooleanConverter>();
                Map(m => m.SuggestedSellingPrice).Name("SuggestedSellingPrice").TypeConverter<CustomDecimalConverter>();
                Map(m => m.ProductBranchMappings).Ignore();
            }
        }
    }
}
