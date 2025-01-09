using System.Xml.Serialization;

namespace BranchProductApp.Core.Parsers
{
    public class BranchExportDto
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("TelephoneNumber")]
        public string TelephoneNumber { get; set; }
        [XmlAttribute("OpenDate")]
        public string OpenDate { get; set; }
    }

}
