namespace BranchProductApp.Core.Models;

public class Branch
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TelephoneNumber { get; set; }
    public DateTime OpenDate { get; set; }
    
    public ICollection<BranchProductMapping> ProductBranchMappings { get; set; }
}