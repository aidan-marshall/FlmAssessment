using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Products;
using BranchProductApp.Core.Parsers.Converters;

namespace BranchProductApp.Core.Parsers
{
    public static class CsvParser
    {
        public static List<Branch> ParseCsv(string filePath)
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

    public class CustomDateTimeConverter : DateTimeConverter
    {
        public override object? ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return DateTime.TryParseExact(text, "yyyy/MM/dd", null, DateTimeStyles.None, out var parsedDate) ? parsedDate : null;
        }
    }

    public class YesNoBooleanConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return text.ToUpper() == "Y";
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return ((bool)value) ? "Y" : "N";
        }
    }
}
