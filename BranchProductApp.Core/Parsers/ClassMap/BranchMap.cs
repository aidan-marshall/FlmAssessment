using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Parsers.Converters;
using CsvHelper.Configuration;

namespace BranchProductApp.Core.Parsers;

public sealed class BranchMap : ClassMap<Branch>
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
