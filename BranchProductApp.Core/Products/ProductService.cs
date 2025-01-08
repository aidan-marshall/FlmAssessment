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
        var product = await dbContext.Products.FindAsync(id);
        if (product == null) throw new KeyNotFoundException();

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
        return true;
    }
}