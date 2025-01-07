using BranchProductApp.Core.Models;

namespace BranchProductApp.Core.Services;

public interface IBranchService
{
    Task<IEnumerable<Branch>> GetAllBranchesAsync();
    Task<Branch> GetBranchByIdAsync(int id);
    Task<Branch> CreateBranchAsync(Branch branch);
    Task<Branch> UpdateBranchAsync(Branch branch);
    Task<bool> DeleteBranchAsync(int id);
}