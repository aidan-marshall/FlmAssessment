using BranchProductApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BranchProductApp.Core.Services
{
    public class ProductBranchMappingService(ApplicationDbContext dbContext) : IProductBranchMappingService
    {
        public async Task AssignProductToBranch(int branchId, int productId)
        {
            var productBranchMapping = new ProductBranchMapping
            {
                BranchId = branchId,
                ProductId = productId
            };

            dbContext.ProductBranchMappings.Add(productBranchMapping);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsForBranch(int branchId)
        {
            return await dbContext.ProductBranchMappings
                .Where(pb => pb.BranchId == branchId)
                .Select(pb => pb.Product)
                .ToListAsync();
        }

        public async Task UnassignProductFromBranch(int branchId, int productId)
        {
            var mapping = await dbContext.ProductBranchMappings
                .Where(pb => pb.BranchId == branchId && pb.ProductId == productId)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException();

            dbContext.ProductBranchMappings.Remove(mapping);
            await dbContext.SaveChangesAsync();
        }
    }
}
