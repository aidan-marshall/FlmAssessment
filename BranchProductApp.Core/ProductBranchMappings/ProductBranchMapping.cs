using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Products;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BranchProductApp.Core.ProductBranchMappings;

public class ProductBranchMapping
{
    public int BranchId { get; set; }
    [JsonIgnore]
    [XmlIgnore]
    [CsvHelper.Configuration.Attributes.Ignore]
    public Branch Branch { get; set; }
    public int ProductId { get; set; }
    [JsonIgnore]
    [XmlIgnore]
    [CsvHelper.Configuration.Attributes.Ignore]
    public Product Product { get; set; }
}