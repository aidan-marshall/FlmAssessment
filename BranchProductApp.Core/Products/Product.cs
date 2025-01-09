using BranchProductApp.Core.ProductBranchMappings;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BranchProductApp.Core.Products;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool WeightedItem { get; set; }
    public decimal? SuggestedSellingPrice { get; set; }
    [JsonIgnore]
    [XmlIgnore]
    public ICollection<ProductBranchMapping> ProductBranchMappings { get; set; }
}