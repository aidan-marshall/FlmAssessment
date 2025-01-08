using BranchProductApp.Core.Models;

namespace BranchProductApp.Core.Services
{
    public interface IProductBranchMappingService
    {
        Task<List<Product>> GetProductsForBranch(int branchId);
        Task AssignProductToBranch(int branchId, int productId);
        Task UnassignProductFromBranch(int branchId, int productId);
    }
}
