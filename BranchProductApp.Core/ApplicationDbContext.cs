using BranchProductApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BranchProductApp.Core;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<BranchProductMapping> ProductBranchMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<BranchProductMapping>()
            .HasKey(pm => new { pm.BranchId, pm.ProductId });
        
        modelBuilder.Entity<BranchProductMapping>()
            .HasOne(pm => pm.Branch)
            .WithMany(b => b.ProductBranchMappings)
            .HasForeignKey(pm => pm.BranchId);

        modelBuilder.Entity<BranchProductMapping>()
            .HasOne(pbm => pbm.Product)
            .WithMany(p => p.ProductBranchMappings)
            .HasForeignKey(pbm => pbm.ProductId);
    }
}