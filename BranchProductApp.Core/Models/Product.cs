namespace BranchProductApp.Core.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool WeightedItem { get; set; }
    public decimal SuggestedSellingPrice { get; set; }
    
    public ICollection<ProductBranchMapping> ProductBranchMappings { get; set; }
}