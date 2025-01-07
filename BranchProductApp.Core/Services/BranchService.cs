using BranchProductApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BranchProductApp.Core.Services;

public class BranchService(ApplicationDbContext dbContext) : IBranchService
{
    public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
    {
        return await dbContext.Branches.ToListAsync();
    }

    public async Task<Branch> GetBranchByIdAsync(int id)
    {
        var result = await dbContext.Branches.FindAsync(id);
        if (result == null) throw new KeyNotFoundException();
        return result;
    }

    public async Task<Branch> CreateBranchAsync(Branch branch)
    {
        await dbContext.Branches.AddAsync(branch);
        await dbContext.SaveChangesAsync();
        return branch;
    }

    public async Task<Branch> UpdateBranchAsync(Branch branch)
    {
        dbContext.Branches.Update(branch);
        await dbContext.SaveChangesAsync();
        return branch;
    }

    public async Task<bool> DeleteBranchAsync(int id)
    {
        var branch = await dbContext.Branches.FindAsync(id);
        if (branch == null) throw new KeyNotFoundException();
        
        dbContext.Branches.Remove(branch);
        await dbContext.SaveChangesAsync();
        return true;
    }
}