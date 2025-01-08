namespace BranchProductApp.Core.Models;

public class ProductBranchMapping
{
    public int BranchId { get; set; }
    public Branch Branch { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}