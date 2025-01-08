using BranchProductApp.Core.Products;

namespace BranchProductApp.Core.ProductBranchMappings
{
    public interface IProductBranchMappingService
    {
        Task<List<Product>> GetProductsForBranch(int branchId);
        Task AssignProductToBranch(int branchId, int productId);
        Task UnassignProductFromBranch(int branchId, int productId);
    }
}
