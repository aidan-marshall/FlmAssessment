using BranchProductApp.Core.ProductBranchMappings;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace BranchProductApp.Core.Branches;

public class Branch
{
    [XmlAttribute("ID")]
    public int Id { get; set; }
    [XmlAttribute("Name")]
    public string Name { get; set; }
    [XmlAttribute("TelephoneNumber")]
    public string? TelephoneNumber { get; set; }
    [XmlAttribute("OpenDate")]
    public DateTime? OpenDate { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public ICollection<ProductBranchMapping> ProductBranchMappings { get; set; }
}