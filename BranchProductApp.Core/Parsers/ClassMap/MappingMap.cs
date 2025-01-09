using BranchProductApp.Core.ProductBranchMappings;
using CsvHelper.Configuration;

namespace BranchProductApp.Core.Parsers;

public sealed class MappingMap : ClassMap<ProductBranchMapping>
{
    public MappingMap()
    {
        Map(m => m.BranchId).Name("BranchID");
        Map(m => m.ProductId).Name("ProductID");
        Map(m => m.Branch).Ignore();
        Map(m => m.Product).Ignore();
    }
}
