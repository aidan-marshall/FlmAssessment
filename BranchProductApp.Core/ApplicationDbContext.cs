using BranchProductApp.Core.Branches;
using BranchProductApp.Core.ProductBranchMappings;
using BranchProductApp.Core.Products;
using Microsoft.EntityFrameworkCore;

namespace BranchProductApp.Core;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBranchMapping> ProductBranchMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ProductBranchMapping>()
            .HasKey(pm => new { pm.BranchId, pm.ProductId });
        
        modelBuilder.Entity<ProductBranchMapping>()
            .HasOne(pm => pm.Branch)
            .WithMany(b => b.ProductBranchMappings)
            .HasForeignKey(pm => pm.BranchId);

        modelBuilder.Entity<ProductBranchMapping>()
            .HasOne(pbm => pbm.Product)
            .WithMany(p => p.ProductBranchMappings)
            .HasForeignKey(pbm => pbm.ProductId);

        modelBuilder.Entity<Branch>()
            .Property(b => b.Id)
            .ValueGeneratedNever();

        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedNever();
    }
}