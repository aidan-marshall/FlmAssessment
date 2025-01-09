using BranchProductApp.Core.Parsers.Converters;
using BranchProductApp.Core.Products;
using CsvHelper.Configuration;

namespace BranchProductApp.Core.Parsers;

public sealed class ProductMap : ClassMap<Product>
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
