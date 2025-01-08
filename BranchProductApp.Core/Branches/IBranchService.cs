namespace BranchProductApp.Core.Branches;

public interface IBranchService
{
    Task<IEnumerable<Branch>> GetBranches();
    Task<Branch> GetBranch(int id);
    Task<Branch> CreateBranch(Branch branch);
    Task<Branch> UpdateBranch(Branch branch);
    Task<bool> DeleteBranch(int id);
    Task AddBranches(List<Branch> branches);
}