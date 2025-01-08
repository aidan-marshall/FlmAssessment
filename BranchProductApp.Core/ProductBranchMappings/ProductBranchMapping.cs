using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Products;

namespace BranchProductApp.Core.ProductBranchMappings;

public class ProductBranchMapping
{
    public int BranchId { get; set; }
    public Branch Branch { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}