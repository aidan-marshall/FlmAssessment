using BranchProductApp.Core.Branches;
using Microsoft.EntityFrameworkCore;

namespace BranchProductApp.Core.Products;

public class ProductService(ApplicationDbContext dbContext) : IProductService
{
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product> GetProduct(int id)
    {
        var result = await dbContext.Products.FindAsync(id);
        if (result == null) throw new KeyNotFoundException();
        return result;
    }

    public async Task<Product> CreateProduct(Product product)
    {
        product.Id = await GenerateNewIdAsync();
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var product = await dbContext.Products.FindAsync(id) ?? throw new KeyNotFoundException();
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task AddProducts(List<Product> products)
    {
        try
        {
            foreach (var product in products)
            {
                if (product.Id == 0)
                {
                    product.Id = await GenerateNewIdAsync();
                }
            }

            dbContext.AddRange(products);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<int> GenerateNewIdAsync()
    {
        var maxId = await dbContext.Branches.MaxAsync(b => (int?)b.Id) ?? 0;
        return maxId + 1;
    }
}