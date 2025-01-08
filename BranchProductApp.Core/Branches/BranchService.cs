using Microsoft.EntityFrameworkCore;

namespace BranchProductApp.Core.Branches;

public class BranchService(ApplicationDbContext dbContext) : IBranchService
{
    public async Task<IEnumerable<Branch>> GetBranches()
    {
        return await dbContext.Branches.ToListAsync();
    }

    public async Task<Branch> GetBranch(int id)
    {
        var result = await dbContext.Branches.FindAsync(id);
        if (result == null) throw new KeyNotFoundException();
        return result;
    }

    public async Task<Branch> CreateBranch(Branch branch)
    {
        branch.Id = await GenerateNewIdAsync();
        await dbContext.Branches.AddAsync(branch);
        await dbContext.SaveChangesAsync();
        return branch;
    }

    public async Task<Branch> UpdateBranch(Branch branch)
    {
        dbContext.Branches.Update(branch);
        await dbContext.SaveChangesAsync();
        return branch;
    }

    public async Task<bool> DeleteBranch(int id)
    {
        var branch = await dbContext.Branches.FindAsync(id);
        if (branch == null) throw new KeyNotFoundException();

        dbContext.Branches.Remove(branch);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task AddBranches(List<Branch> branches)
    {
        try
        {
            foreach (var branch in branches)
            {
                if (branch.Id == null || branch.Id == 0)
                {
                    branch.Id = await GenerateNewIdAsync();
                }
            }

            dbContext.AddRange(branches);
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